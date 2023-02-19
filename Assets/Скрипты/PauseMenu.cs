using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    public GameObject MainCanvas;
    public GameObject PauseCanvas;

    public void Pause()
    {
        if (PlayerPrefs.GetInt("isPaused") == 0) 
        {
            Time.timeScale = 1;
            MainCanvas.SetActive(true);
            PauseCanvas.SetActive(false);
            PlayerPrefs.SetInt("isPaused", 1);

        }
        else
        {
            Time.timeScale = 0;
            MainCanvas.SetActive(false);
            PauseCanvas.SetActive(true);
            PlayerPrefs.SetInt("isPaused", 0);
        }
    }
}
