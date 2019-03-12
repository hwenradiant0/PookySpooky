using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static bool GameIsOver;

    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public GameObject GameMaster;
    public GameObject GameMaster_2;
    

	void Start ()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update ()
    {
		if (GameIsOver)
			return;

		if (PlayerStats.Lives <= 0)
		{
			EndGame();
		}

        if (WaveSpawner.W_countdown <= 1)
        {
            RoundClear();
        }
	}

    void RoundClear()
    {
        GameMaster.SetActive(false);
        GameMaster_2.SetActive(true);
    }

	void EndGame ()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
        Time.timeScale = 0.0f;
    }
}
