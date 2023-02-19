using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsSaver : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("currentShip", 0);
        PlayerPrefs.SetInt("Currentlevel", 1);
        PlayerPrefs.SetInt("Score", 1000000);
        PlayerPrefs.SetInt("PlayerShip",0);
        PlayerPrefs.SetInt("SelectedShip", 0);
        PlayerPrefs.Save();
    }

}
