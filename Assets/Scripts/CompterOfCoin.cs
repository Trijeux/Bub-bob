using UnityEngine;
using UnityEngine.UI;

public class CompterOfCoin : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCounrText;
    
    public static CompterOfCoin instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("CompterOfCoin déjà créer");
            return;
        }
        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCounrText.text = coinsCount.ToString();
    }
}
