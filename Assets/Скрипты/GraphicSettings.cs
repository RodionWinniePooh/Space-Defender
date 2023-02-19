using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GraphicSettings : MonoBehaviour
{

    public Dropdown dropDown;
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("QualityLevel"));
        string[] temp = QualitySettings.names;
        List<string> quality = new List<string>();
        for (int i = 0; i < temp.Length; i++)
        {
            quality.Add(temp[i]);
        }
        dropDown.ClearOptions();
        dropDown.AddOptions(quality);
        dropDown.value = QualitySettings.GetQualityLevel();
    }
    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(dropDown.value);
        PlayerPrefs.SetInt("QualityLevel", dropDown.value);
        PlayerPrefs.Save();
    }
}
