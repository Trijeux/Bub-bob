using UnityEngine;

public class DeadSpike : MonoBehaviour
{
    public bool Dead = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Dead = true;
        }
    }
}
