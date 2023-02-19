using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitConfirmButton : MonoBehaviour
{

    public Canvas MainMenu;
    public Canvas ExitCanvas;
    public bool exit = false;

    public AudioSource click;
    public void OnClick()
    {
        click.Play();
        exit = !exit;      
    }
    private void Update()
    {
        if (exit)
        {
            MainMenu.gameObject.SetActive(false);
            ExitCanvas.gameObject.SetActive(true);
        }
        if (!exit)
        {
            MainMenu.gameObject.SetActive(true);
            ExitCanvas.gameObject.SetActive(false);
        }
    }
}
