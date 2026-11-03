using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    AudioManager GameAudio;
    Ball ball;
    private void Awake()
    {
        GameAudio = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Restart()
    {
        
        GameAudio.PlaySFX(GameAudio.buttonclick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ball.GameEnD = false;
        Time.timeScale = 1;
    }

    public void Menu()
    {
        GameAudio.PlaySFX(GameAudio.buttonclick);
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        GameAudio.PlaySFX(GameAudio.buttonclick);
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 0;
    }
}
