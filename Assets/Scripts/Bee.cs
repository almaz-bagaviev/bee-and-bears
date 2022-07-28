using UnityEngine;

public class Bee : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ToLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            ToRight();
        }
    }

    private void ToLeft()
    {
        if (transform.position.x != -1.9f)
        {
            transform.position = new Vector3(transform.position.x - 1.9f, transform.position.y, transform.position.z);
        }
    }

    private void ToRight()
    {
        if (transform.position.x != 1.9f)
        {
            transform.position = new Vector3(transform.position.x + 1.9f, transform.position.y, transform.position.z);
        }
    }
}
