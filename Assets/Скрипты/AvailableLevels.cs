using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableLevels : MonoBehaviour
{
    [Header("Позиция для размещения галочек или крестиков")]
    public GameObject[] check;
    [Header("Все кнопки уровней")]
    public GameObject[] buttons;
    [Header("Картинка Галочки")]
    public Image available;
    [Header("Картинка Крестика")]
    public Image Lock;
    [Header("Картинка Текущего уровня")]
    public Image Current;

    void Start()
    {
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        int availableLevel = PlayerPrefs.GetInt("AvailableLevel");
        for (int i = 0; i < check.Length; i++)
        {
            if(i<currentLevel)
            {
                Instantiate(available, check[i].transform);
            }
            else
            if(i==currentLevel)
            {
                Instantiate(Current, check[i].transform);
            }
            else
            {
                Instantiate(Lock, check[i].transform);
            }
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            if (availableLevel>=i)
            {
                buttons[i].GetComponent<Button>().enabled = true;
            }
            else
            {
                buttons[i].GetComponent<Button>().enabled = false;
            }
        }
    }
}
