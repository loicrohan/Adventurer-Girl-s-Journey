using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverLvL2 : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;
    [SerializeField]
    private Text currentScore;
    [SerializeField]
    private Text finalScore;

    public void SetGameOver()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = "    Finale " + currentScore.text;
        currentScore.gameObject.SetActive(false);
        Time.timeScale = 0;
    }

    public void ClickOnReplay()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1f;
    }

    public void ClickOnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}