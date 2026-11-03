using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audiomanager;
    MusicSwith musicSwith;

    [SerializeField] GameObject OptionPanel;
    [SerializeField] GameObject AudioPanel;
    [SerializeField] GameObject ControlPanel;
    [SerializeField] GameObject MapPanel;

    private void Awake()
    {
        audiomanager  = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void PlayGame()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        MapPanel.SetActive(true);
    }

    public void MapMenuClose()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        MapPanel.SetActive(false);
    }

    public void IndoorLevel()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1;
    }

    public void OutDoor()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        SceneManager.LoadSceneAsync(3);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        Application.Quit();
        Time.timeScale = 0;
    }

    public void OptionMenu()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        OptionPanel.SetActive(true);
    }

    public void OptionmenuClose()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        OptionPanel.SetActive(false);
    }

    public void AudioMenu()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        AudioPanel.SetActive(true);
    }

    public void AudiomenuClose()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        AudioPanel.SetActive(false);
    }

    public void ControlMenu()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        ControlPanel.SetActive(true);
    }

    public void ControlmenuClose()
    {
        audiomanager.PlaySFX(audiomanager.buttonclick);
        ControlPanel.SetActive(false);
    }

}
