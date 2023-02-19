using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GroundEndLevelManager : MonoBehaviour
{
    public GameObject player;

    public Text CurrentScore;

    public Text EndScore;
    public Text Money;

    public Canvas MainCanvas;
    public Canvas LevelFail;
    public Canvas LevelComplete;

    void Update()
    {
        if(player.activeInHierarchy==false)
        {
            LevelFail.gameObject.SetActive(true);
            MainCanvas.gameObject.SetActive(false);
        }
        if(player.GetComponent<CharacterMove>().isWin)
        {
            LevelComplete.gameObject.SetActive(true);
            MainCanvas.gameObject.SetActive(false);
            EndScore.text = "Score:"+CurrentScore.text;
            Money.text = (PlayerPrefs.GetInt("Score") + int.Parse(CurrentScore.text)).ToString();
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + int.Parse(CurrentScore.text));
            PlayerPrefs.SetInt("AvailableLevel", PlayerPrefs.GetInt("AvailableLevel") + 1);
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
            PlayerPrefs.Save();
            Destroy(gameObject);
        }
    }
}
