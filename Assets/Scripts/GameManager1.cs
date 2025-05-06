using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public int coinsCounter = 0;
    public Text coinText;

    // Update is called once per frame
    void Update()
    {
        coinText.text = coinsCounter.ToString();
    }
}
