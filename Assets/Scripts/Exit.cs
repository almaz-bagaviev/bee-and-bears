using UnityEngine;

public class Exit : MonoBehaviour
{
    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Debug.Log("Выход из игры");
                Application.Quit();
                return;
            }
        }
    }
}
