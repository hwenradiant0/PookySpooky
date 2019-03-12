using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Press_Button : MonoBehaviour
{
    public void Pressbutton(string Scene)
    {
        SceneManager.LoadScene(Scene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
            Application.Quit ();

#endif
    }
}
