using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoading : MonoBehaviour
{
    [Header("ID загружаемой сцены")]
    public int sceneID;

    [Header("Картинка которую будем заполнять")]
    public Image loadingImg;
    [Header("Текст прогресса")]
    public Text progressText;

    void Start()
    {
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            loadingImg.fillAmount = progress;
            progressText.text = string.Format("{0:0}%",progress*100);
            yield return null;
        }
    }
}
