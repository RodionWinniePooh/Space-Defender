using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountText : MonoBehaviour
{
    public long count;
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Text>().text = count.ToString();
    }
}
