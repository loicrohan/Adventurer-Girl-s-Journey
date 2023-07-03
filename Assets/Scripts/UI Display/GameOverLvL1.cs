using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverLvL1 : MonoBehaviour
{
    public void ClickOnReplay()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1f;
    }

    public void ClickOnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
