using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public static int coin;
    public static Text cointext;

    private void Start()
    {
        cointext = gameObject.GetComponent<Text>();
        coin = PlayerPrefs.GetInt("Coin", coin);
    }

    private void Update()
    {
        cointext.text = coin.ToString();
    }
}
