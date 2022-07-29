using UnityEngine;

public class Swapper : MonoBehaviour
{

    public GameObject[] character;
    public int index;
    public Texture btn_tex;

    private void Awake()
    {
        foreach (GameObject g in character)
        {
            g.SetActive(false);
        }

        character[0].SetActive(true);
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width - 100, 0, 100, 100), btn_tex))
        {
            character[index].SetActive(false);
            index++;
            index %= character.Length;
            character[index].SetActive(true);
        }
    }
}

