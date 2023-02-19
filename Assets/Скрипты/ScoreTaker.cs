using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTaker : MonoBehaviour
{
    private Text score;
    // Update is called once per frame
    void Update()
    {
        score = GetComponent<Text>();
        score.text = PlayerPrefs.GetInt("Score").ToString()+"$";
    }
}
