using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeShips : MonoBehaviour
{
    public Sprite[] Ships;
    public int[] ShipsCost;
    public int currentship;
    public bool Change;

    public AudioSource click;

    private void Start()
    {
        currentship = PlayerPrefs.GetInt("currentShip");
        this.GetComponent<Image>().sprite = Ships[currentship];
    }

    public void Next()
    {
        click.Play();
        if(currentship<Ships.Length-1)
        {
            this.GetComponent<Image>().sprite = Ships[currentship+1];
            currentship++;
            Change = true;
            PlayerPrefs.SetInt("currentShip",currentship);
        }
        else
        {
            currentship = 0;
            this.GetComponent<Image>().sprite = Ships[currentship];
            Change = true;
            PlayerPrefs.SetInt("currentShip", currentship);
        }
    }
    public void Previous()
    {
        click.Play();
        if (currentship > 0)
        {
            this.GetComponent<Image>().sprite = Ships[currentship - 1];
            currentship--;
            Change = true;
            PlayerPrefs.SetInt("currentShip", currentship);
        }
        else
        {
            currentship = Ships.Length-1;
            this.GetComponent<Image>().sprite = Ships[currentship];
            Change = true;
            PlayerPrefs.SetInt("currentShip", currentship);
        }
    }
}
