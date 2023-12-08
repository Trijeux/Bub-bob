using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFall : MonoBehaviour
{
    public bool isFall;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Is Fall");
            isFall = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Isn't Fall");
            isFall = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Is Grounded");
            isFall = true;
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Isn't Grounded");
            isFall = false;
        }
    }
}
