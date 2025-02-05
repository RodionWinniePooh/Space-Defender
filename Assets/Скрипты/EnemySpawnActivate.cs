﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnActivate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameObject.GetComponentInParent<EnemySpawn>().enabled = true;
        }
    }
}
