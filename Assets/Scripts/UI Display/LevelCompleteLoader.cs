using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteLoader : MonoBehaviour
{
    public void ClickOnNext()
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