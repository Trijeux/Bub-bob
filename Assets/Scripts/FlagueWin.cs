using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagueWin : MonoBehaviour
{
    public bool flagewin;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flagewin = true;
        }
    }
}
