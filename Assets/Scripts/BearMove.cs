using UnityEngine;

public class BearMove : MonoBehaviour
{
    public float speed;
    private Animator Anim;

    private void Awake()
    {
        Anim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        Anim.SetBool("isRunning", true);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
