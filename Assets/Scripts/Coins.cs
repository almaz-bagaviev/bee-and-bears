using UnityEngine;

public class Coins : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Lose.LoseBee)
        {
            CoinsText.coin += 10;
            PlayerPrefs.SetInt("Coin", CoinsText.coin);
            Destroy(gameObject);
        }
    }
}