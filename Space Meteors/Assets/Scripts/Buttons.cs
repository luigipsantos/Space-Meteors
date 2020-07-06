using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Home");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1;
    }
}
