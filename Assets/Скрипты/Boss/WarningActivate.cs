using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningActivate : MonoBehaviour
{
    public GameObject Warning;

    public void Activate()
    {
        Warning.SetActive(true);
        Destroy(this.gameObject);
    }
}
