using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject Enemy;

    [Header("Количество появляющихся врагов на этой точке")]
    public int SpawnCount=0;
    private int tempCount=0;
    [Header("Время между появлением врагов")]
    public float spawnTime=2f;

    private float tempTime;

    void Update()
    {
        tempTime += Time.deltaTime;
        if(tempTime>=spawnTime && tempCount<SpawnCount)
        {
            Instantiate(Enemy, transform.position, transform.rotation);
            tempTime = 0;
            tempCount++;
        }
    }
}
