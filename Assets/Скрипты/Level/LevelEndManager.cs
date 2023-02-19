using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelEndManager : MonoBehaviour
{
    [Header("Номер уровня")]
    public int levelNum;

    public Canvas EndCanvas;
    public Canvas UserInterface;
    public Canvas FailCanvas;
    public Text scoretext;
    public Text money;
    public Text moneyFail;
    public BossRoqueOne boss;
    public PlayerMoving player;
    public GameObject finalPlanet;

    private bool isFinish;
    private void Start()
    {
        if (PlayerPrefs.GetInt("AvailableLevel") >= levelNum - 1)
        {
            isFinish = false;
        }
        else isFinish = true;
    }
    void Update()
    {
        if (player.isAlive==false)
        {
            UserInterface.gameObject.SetActive(false);
            FailCanvas.gameObject.SetActive(true);
            moneyFail.text = PlayerPrefs.GetInt("Score").ToString() + "$";
            Destroy(this.gameObject);
        }
            if (boss.isDefeated && player.isAlive)
            {
                EndCanvas.gameObject.SetActive(true);
                scoretext.text = "Score:" + FindObjectOfType<CountText>().count.ToString();
                money.text = (PlayerPrefs.GetInt("Score") + FindObjectOfType<CountText>().count).ToString() + "$";
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + (int)(FindObjectOfType<CountText>().count));
                PlayerPrefs.Save();
                FindObjectOfType<PlayerShooting>().isFinish = true;
                UserInterface.gameObject.SetActive(false);
                //Instantiate(finalPlanet);
                if(!isFinish)
                {
                PlayerPrefs.SetInt("AvailableLevel", PlayerPrefs.GetInt("AvailableLevel") +1);
                PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel") + 1);
                PlayerPrefs.Save();
                }
                Destroy(this.gameObject);
            }
    }
}
