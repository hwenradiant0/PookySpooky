using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLifeUI : MonoBehaviour {

    public Text Life;

    private void Update()
    {
        Life.text = "LIFE : " + PlayerStats.Lives.ToString();
    }
}
