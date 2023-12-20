using UnityEngine;
using UnityEngine.UI;

public class StringCoinsWinScore : MonoBehaviour
{
    public CoinManager _coinManager;
    public Text coinsCountTextScore;
    [SerializeField] private int coinsstring;
    void Update()
    {
        coinsstring = _coinManager.coins;
        coinsCountTextScore.text = coinsstring.ToString();
    }
}
