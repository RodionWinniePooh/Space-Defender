using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingWithCircle : MonoBehaviour
{
    [Header("ID загружаемой сцены")]
    public int sceneID;
    [Header("Префаб ProgressBar'а")]
    public SceneLoading loader;
    [Header("Звук нажатия на кнопку")]
    public AudioSource clickSound;

    public void LoadScene()
    {
        clickSound.Play();
        loader.sceneID = sceneID;
        loader.gameObject.SetActive(true);
    }
}
