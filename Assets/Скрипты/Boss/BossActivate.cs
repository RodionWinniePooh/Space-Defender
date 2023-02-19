using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivate : MonoBehaviour
{
    public GameObject Boss;
    public LevelEndManager lvl;

    public void Activate()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Warning");
        foreach (var item in obj)
        {
            Destroy(item);
        }
        Boss.SetActive(true);
        //lvl.boss = Boss.GetComponent<BossRoqueOne>();
        Destroy(this.gameObject);
    }
}
