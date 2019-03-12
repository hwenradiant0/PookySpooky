using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClosePopUp : MonoBehaviour
{

    public GameObject OptionWindow;

    public void Pressbutton()
    {
        OptionWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
