using UnityEngine;
using UnityEngine.UI;

public class WinUI : MonoBehaviour
{
    public Text levelCoinText;
    public Text totalCoinText;

    void Start()
    {
        int levelCoin = PlayerPrefs.GetInt("LastLevelCoin", 0);
        int totalCoin = PlayerPrefs.GetInt("TotalCoin", 0);

        levelCoinText.text = "Your Coin In This Map is  " + levelCoin;
        totalCoinText.text = "Total Coin: " + totalCoin;
    }
}