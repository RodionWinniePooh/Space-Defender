using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    private ChangeShips change;
    public Text Cost;
    public Text BuyText;
    public Text MoneyCount;
    public Text Select;
    private int playerShip;
    private float warningTime=5;
    private float time=5;

    public AudioSource click;

    public int shift;

    private void Start()
    {
        change = FindObjectOfType<ChangeShips>();
    }
    void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("ThirdShip"));
        if(PlayerPrefs.GetInt("SecondShip") == 1)
        {
            playerShip = 1;
        }
        else
        if (PlayerPrefs.GetInt("ThirdShip") == 1)
        {
            playerShip = 2;
        }
        else playerShip = 0;
        UpdateButtonText();
        time += Time.deltaTime;
        if (time < warningTime)
        MoneyCount.gameObject.SetActive(true);
        else MoneyCount.gameObject.SetActive(false);
    }

    public void BuySelect()
    {
        click.Play();
        if(playerShip>=change.currentship)
        {
            BuyText.text = "Selected";
        }
        else
        {
            int money= PlayerPrefs.GetInt("Score");
            string cost = Cost.text.Remove(Cost.text.Length-1);
            if (money >= int.Parse(cost))
            {
                money -= int.Parse(cost);
                PlayerPrefs.SetInt("Score", money);
                if(change.currentship==1)
                {
                    PlayerPrefs.SetInt("SecondShip",1);
                }
                if (change.currentship == 2)
                {
                    PlayerPrefs.SetInt("ThirdShip",1);
                }
            }
            else
            {
                time = 0;
            }
        }
    }

    void UpdateButtonText()
    {
        switch (change.currentship)
        {

            case 0:
                {
                    BuyText.gameObject.SetActive(false);
                    Select.gameObject.SetActive(true);
                    Cost.enabled = false;
                    break;
                }
            case 1:
                {
                    if(playerShip>=1)
                    {
                        BuyText.gameObject.SetActive(false);
                        Select.gameObject.SetActive(true);
                        Cost.enabled = false;
                    }
                    else
                    {
                        BuyText.text = "Buy:";
                        Cost.enabled = true;
                        BuyText.gameObject.SetActive(true);
                        Select.gameObject.SetActive(false);
                        Cost.text = change.ShipsCost[change.currentship].ToString() + "$";
                    }
                    break;
                }
            case 2:
                {
                    if (playerShip == 2)
                    {
                        BuyText.gameObject.SetActive(false);
                        Select.gameObject.SetActive(true);
                        Cost.enabled = false;
                    }
                    else
                    {
                        BuyText.text = "Buy:";
                        Cost.enabled = true;
                        BuyText.gameObject.SetActive(true);
                        Select.gameObject.SetActive(false);
                        Cost.text = change.ShipsCost[change.currentship].ToString() + "$";
                    }
                    break;
                }
            default:
                break;
        }
    }
}
