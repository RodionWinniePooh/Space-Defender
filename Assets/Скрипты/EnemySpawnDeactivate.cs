using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnDeactivate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            gameObject.GetComponentInParent<EnemySpawn>().gameObject.SetActive(false);
        }
    }
}
