using UnityEngine;
using UnityEngine.UI;

public class CompterOfCoin : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;
    
    public static CompterOfCoin instance;
    public CoinManager _CoinManager;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("CompterOfCoin déjà créer");
            return;
        }
        instance = this;
    }

    public void StringCoins()
    {
        coinsCount = _CoinManager.coins;
        coinsCountText.text = coinsCount.ToString();
    }
}
