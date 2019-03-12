using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour {

    public string menuSceneName = "MainMenu";

    public SceneFader sceneFader;

    public void Retry()
    {
        Time.timeScale = 1.0f;
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        Time.timeScale = 1.0f;
        sceneFader.FadeTo(menuSceneName);
    }
}
