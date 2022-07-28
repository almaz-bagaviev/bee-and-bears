using System.Collections;
using UnityEngine;

public class SpawnBearsOrCoins : MonoBehaviour
{
    public GameObject [] EnemyOrCoins;
    public Transform [] PositionOfSpawn;
    int RandomObjects, RandomPosition;


    private void Start()
    {
        StartCoroutine(NewSpawn());
    }

    IEnumerator NewSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            RandomObjects = Random.Range(0, EnemyOrCoins.Length);
            RandomPosition = Random.Range(0, PositionOfSpawn.Length);
            Instantiate(EnemyOrCoins[RandomObjects], PositionOfSpawn[RandomPosition].position, Quaternion.Euler(new Vector3(0, 180f, 0)));
        }
    }
}
