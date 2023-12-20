using UnityEngine;
public class PickUpCoin : MonoBehaviour
{
    [SerializeField] private CoinManager _coinManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _coinManager.coins++;
            CompterOfCoin.instance.StringCoins();
            Destroy(gameObject);
        }
    }
}
