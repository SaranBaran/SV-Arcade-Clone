using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public int EnemySpeed;
    public GameObject player;

    void Update()
    {
        Vector3 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized;
        transform.Translate(localPosition.x * Time.deltaTime * EnemySpeed,
                            0f,
                            localPosition.z * Time.deltaTime * EnemySpeed);
    }
}
