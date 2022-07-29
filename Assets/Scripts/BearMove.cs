using UnityEngine;

public class BearMove : MonoBehaviour
{
    public float speed;
    private Animator anim;

    private void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    private void Start()
    {
        anim.SetBool("isRunning", true);
    }

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
