using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ChangeScene_Title : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void Pressbutton()
    {
        SceneManager.LoadScene("Title");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
