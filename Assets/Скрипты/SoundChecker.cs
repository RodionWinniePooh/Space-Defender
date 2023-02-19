using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundChecker : MonoBehaviour
{
    public bool isChecked;

    private void Start()
    {
        int temp = PlayerPrefs.GetInt("Sound");
        if(temp == 1)
        {
            GetComponent<Toggle>().isOn = true;
            isChecked = true;
        }
        else
        {
            GetComponent<Toggle>().isOn = false;
            isChecked = false;
        }
    }

    public void OnClick()
    {
        if (isChecked)
            PlayerPrefs.SetInt("Sound", 0);
        else PlayerPrefs.SetInt("Sound", 1);
        PlayerPrefs.Save();
        isChecked = !isChecked;
    }
}
