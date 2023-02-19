using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public GameObject[] playerShips;
    private int ship;
    private void Start()
    {
        ship = PlayerPrefs.GetInt("SelectedShip");

        for (int i = 0; i < playerShips.Length; i++)
        {
            if (i != ship)
            {
                playerShips[i].SetActive(false);
            }
            else
            {
                playerShips[i].SetActive(true);
                FindObjectOfType<LevelEndManager>().player = playerShips[i].GetComponent<PlayerMoving>();
            }
        }
    }

}
