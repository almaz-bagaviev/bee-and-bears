using UnityEngine;

public class TunnelGoBears : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bear") && Lose.LoseBee)
        {
            CoinsText.coin++;
            PlayerPrefs.SetInt("Coin", CoinsText.coin);
        }
    }
}