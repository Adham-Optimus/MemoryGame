using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class SceneManagement : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public void ChangeScenes(int number)
    {
        SceneManager.LoadScene(number);
    }
    public void Exit()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
    public void SetQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    
}
