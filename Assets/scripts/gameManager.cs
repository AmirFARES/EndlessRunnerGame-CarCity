using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;
public class gameManager : MonoBehaviour
{
    bool gameOver = false;
    public Transform player;
    public TMP_Text scoreTextUI;
    public TMP_Text scoreTextEnd;
    public AudioSource engineSound;
    public AudioSource accidentSound;
    public void GameOver()
    {
        if (!gameOver)
        {
            gameOver = true;
            engineSound.Stop();
            accidentSound.Play();
            GameObject.Find("/Main Camera/Canvas/endMenu").SetActive(true);
            scoreTextEnd.text = player.position.z.ToString("0");
            GameObject.Find("/Main Camera/Canvas/gameUI").SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Time.timeScale = 1f;
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    void Update()
    {
        scoreTextUI.text= player.position.z.ToString("0");
    }
}
