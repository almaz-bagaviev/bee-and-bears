using UnityEngine;

public class CreateNewGround : MonoBehaviour
{
    public GameObject nowBG;
    public GameObject[] BG2;
    GameObject newBG;
    int RandomBG2;

    private void Update()
    {
        if (nowBG.transform.position.z < 0f && newBG == null) //и если новый фон не создан
            CreateBackground();
        else if (newBG != null && newBG.transform.position.z < 0f)
            CreateBackground();
    }

    private void CreateBackground()
    {
        if (nowBG.transform.position.z < -110.1f)
        {
            Destroy(nowBG);
            nowBG = newBG;
        }

        RandomBG2 = Random.Range(0, BG2.Length);
        newBG = Instantiate(BG2[RandomBG2], new Vector3(0, 0, 110.1f), Quaternion.identity);
    }
}
