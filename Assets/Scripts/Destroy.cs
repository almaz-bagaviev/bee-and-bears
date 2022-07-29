using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void Update()
    {
        if (gameObject.transform.position.z < -300f) Destroy(gameObject);
    }
}
