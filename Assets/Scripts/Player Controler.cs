using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 2;
    [SerializeField] private float jump_force = 2;
    public IsGrounded _grounded;
    public IsFall _fall;
    private Animator _animator;
    private bool isfall = false;
    private int isfallstart = 0;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame

    void Update()
    {
        if (_grounded.isGrounded && !isfall)
        {
            _rb.velocityY = Input.GetAxis("Jump") * jump_force;
            if (_rb.velocity.y >= 0.1f)
            {
                //Debug.Log("test");
                _animator.SetBool("IsJump", true);
            }
            else
            {
                _animator.SetBool("IsJump", false);
            }
        }

        if (!_fall.isFall && Input.GetAxis("Jump") <= 0)
        {
            _animator.SetBool("IsFall", true);
            isfall = true;
            isfallstart++;
            if (isfallstart == 1)
            {
                _rb.gravityScale /= 3f;
            }
        }
        else
        {
            _animator.SetBool("IsFall", false);
            if (isfall)
            {
                _rb.gravityScale *= 3f;
                isfall = false;
                isfallstart = 0;
            }
        }
    }

    void FixedUpdate()
    {
        _rb.velocityX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        if (_rb.velocity.x <= -0.1f)
        {
            _sr.flipX = true;
            if (!(_rb.velocity.y >= 0.1f))
            {
                _animator.SetBool("IsWalking", true);
            }
        }
        else if (_rb.velocity.x >= 0.1f)
        {
            _sr.flipX = false;
            if (!(_rb.velocity.y >= 0.1f))
            {
                _animator.SetBool("IsWalking", true);
            }
        }
        else
        {
            if (!(_rb.velocity.y >= 0.1f))
            {
                _animator.SetBool("IsWalking", false);
            }
        }
    }
}