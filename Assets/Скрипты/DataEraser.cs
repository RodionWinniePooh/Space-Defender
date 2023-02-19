using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataEraser : MonoBehaviour
{
    public void Erase()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Sound", 0);
        PlayerPrefs.SetInt("QualityLevel", 2);
        PlayerPrefs.SetInt("currentShip", 0);
        PlayerPrefs.SetInt("Currentlevel", 1);
        PlayerPrefs.SetInt("Score", 1000000);
        PlayerPrefs.SetInt("FirstShip", 1);
        PlayerPrefs.SetInt("SecondShip", 0);
        PlayerPrefs.SetInt("ThirdShip", 0);
        PlayerPrefs.SetInt("SelectedShip", 0);
        PlayerPrefs.SetInt("isPaused", 0);
        PlayerPrefs.SetInt("CurrentLevel", 0);
        PlayerPrefs.SetInt("AvailableLevel", 0);
        PlayerPrefs.SetFloat("Volume", 0);
        PlayerPrefs.Save();
    }
}
