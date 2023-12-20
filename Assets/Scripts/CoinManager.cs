using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "CoinManager", menuName = "ScriptableObjects/CoinManager", order = 1)]
public class CoinManager : ScriptableObject
{
    public int coins;

    public void resetCoins()
    {
        coins = 0;
    }
}

