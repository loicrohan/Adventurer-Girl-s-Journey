using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    public void ClickOnPause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClickOnResume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickOnQuit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}