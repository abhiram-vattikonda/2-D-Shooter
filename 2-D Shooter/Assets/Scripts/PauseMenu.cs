using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] private GameObject powerMenu;

    public static void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }
    public static void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void GotoMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Game");
    }
}
