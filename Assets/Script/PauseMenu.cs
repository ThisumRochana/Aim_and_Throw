using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    AudioManager GameAudio;

    [SerializeField] GameObject _PauseMenu;

    private void Awake()
    {
        GameAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Pause()
    {
        _PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Home()
    {
        GameAudio.PlaySFX(GameAudio.buttonclick);
        SceneManager.LoadScene("Main Menu");
    }

    public void Resume()
    {
        GameAudio.PlaySFX(GameAudio.buttonclick);
        _PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
}
