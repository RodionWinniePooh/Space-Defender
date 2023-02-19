using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundEnabler : MonoBehaviour
{
    public AudioMixer mixer;

    private Slider slider;
    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = int.Parse(PlayerPrefs.GetFloat("Volume").ToString());
        Application.targetFrameRate = 61;
        Time.timeScale = 1;      
    }
    public void Change()
    {
        float volume;
        mixer.SetFloat("Volume", slider.value);
        mixer.GetFloat("Volume", out volume);
        Debug.Log(volume);
        PlayerPrefs.SetFloat("Volume", slider.value);
        PlayerPrefs.Save();
    }
}
