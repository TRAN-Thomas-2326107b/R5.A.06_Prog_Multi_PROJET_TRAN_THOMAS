using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int coins = 0;
    public TMP_Text coinsCounter;

    public void AddCoins(int amount)
    {
        coins += amount;
        Debug.Log("Coins : " + coins);
        UpdateUI();
    }

    public bool SpendCoins(int amount)
    {
        if (coins < amount) return false;

        coins -= amount;
        UpdateUI();
        return true;
    }

    void UpdateUI()
    {
        if (coinsCounter != null)
            coinsCounter.text = coins.ToString();
    }
}
