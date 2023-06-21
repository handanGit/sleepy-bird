using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class logicSC : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text scoreTextOver;
    public Text HighScoreTX;
    public GameObject gameOverScreen;
    public GameObject CliskShowcase;
    public GameObject APscoreText;

    [ContextMenu("increase score")]
    [ContextMenu("HighScore")]

    private void Start()
    {
        HighScoreTX.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        //updateHighScore();
    }
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        CliskShowcase.SetActive(false);
    }

    public void updateHighScore()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            HighScoreTX.text = playerScore.ToString();
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        APscoreText.SetActive(true);
        Time.timeScale = 1f;
        Debug.Log("Game Restarted");

    }

    public void gameOver()
    {
        if (playerScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", playerScore);
            HighScoreTX.text = playerScore.ToString();
        }

        APscoreText.SetActive(false);
        scoreTextOver.text = playerScore.ToString();
        gameOverScreen.SetActive(true);
        CliskShowcase.SetActive(false);
        Time.timeScale = 0f;
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
    }

    public void openPortovolio()
    {
        Application.OpenURL("https://drive.google.com/drive/folders/19IYx30TtUNG2TVZE4pixT3wyAJDXW7p9?usp=sharing");
        Debug.Log("Open external link(portovolio)");
    }
}
