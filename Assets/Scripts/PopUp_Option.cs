using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PopUp_Option : MonoBehaviour
{

    public GameObject OptionWindow;
    
    public void Pressbutton()
    {
        OptionWindow.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
