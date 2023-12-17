using UnityEngine;
public class PickUpCoin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CompterOfCoin.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
