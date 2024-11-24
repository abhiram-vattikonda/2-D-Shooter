using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
