using UnityEngine;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    [SerializeField] private float speed = 2;
    [SerializeField] private float jump_force = 2;
    public IsGrounded _grounded;
    private Animator _animator;
    public PlayerReRespawn _spawn;
    public DeadSpike _dead;
    public SetSpawnPoint _FlagePoint;
    public FlagueWin _FlagueWin;
    private bool isfall = false;
    public string WinScene;
    public string DeadScene;
    [SerializeField] private int LifePlayer = 3;
    public Text LifePlayerCount;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _spawn.SpawnPoint = transform.position;
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
        
        else
        {
            _animator.SetBool("IsFall", false);
            if (isfall)
            {
                _rb.gravityScale *= 3f;
                isfall = false;
            }
        }

        if (_dead.Dead == true)
        {
            _spawn.ReSpawn();
            LifePlayer -= 1;
            LifePlayerCount.text = LifePlayer.ToString();
            _dead.Dead = false;
        }

        if (_FlagePoint.flagepoint == true)
        {
            _spawn.SpawnPoint = transform.position;
            _FlagePoint.flagepoint = false;
        }

        if (_FlagueWin.flagewin == true)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(WinScene);
        }

        if (LifePlayer <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(DeadScene);
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