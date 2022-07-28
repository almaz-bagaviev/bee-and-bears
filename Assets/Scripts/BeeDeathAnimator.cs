using UnityEngine;

public class BeeDeathAnimator : MonoBehaviour
{
    Animator AnimBee;

    private void Start()
    {
        AnimBee = gameObject.GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bear") || collision.gameObject.CompareTag("Let"))
        {
            AnimBee.SetBool("isDeath", true);
        }
    }
}
