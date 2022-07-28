using UnityEngine;

public class MoveGround : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
    }
}
