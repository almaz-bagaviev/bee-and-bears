using UnityEngine;

public class Lose : MonoBehaviour
{
    Animator AnimCamera;
    public static bool LoseBee;

    private void Start()
    {
        AnimCamera = GameObject.Find("Main Camera").GetComponent<Animator>();
        LoseBee = true;
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bear") || collision.gameObject.CompareTag("Let"))
        {
            AnimCamera.SetBool("isCameraGo", true);
            Debug.Log("Коллизия произошла");
            LoseBee = false;

        }
    }
}
