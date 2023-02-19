using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public int level;
    public AudioSource click;
    public void OnClick()
    {
        click.Play();
        Application.LoadLevel(level);
    }
}
