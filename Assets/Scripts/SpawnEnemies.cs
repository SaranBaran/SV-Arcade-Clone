using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject enemy;
    public float secondsBetween = 0.5f;
    public int xMin;
    public int xMax;
    public int zMin;
    public int zMax;
    int xPosition;
    int zPosition;
    int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 50)
        {
            xPosition = Random.Range(xMin, xMax);
            zPosition = Random.Range(zMin, zMax);
            Instantiate(enemy, new Vector3(xPosition,1, zPosition), Quaternion.identity);
            yield return new WaitForSeconds(secondsBetween);
        }

    }

}
