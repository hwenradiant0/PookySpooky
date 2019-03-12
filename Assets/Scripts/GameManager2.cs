using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour {

    public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject gameClearUI;


    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
            return;

        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }

        if (WaveSpawner.W_countdown <= 1)
        {
            GameClear();
        }

    }

    void GameClear()
    {
        GameIsOver = true;
        gameClearUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }

    
}
