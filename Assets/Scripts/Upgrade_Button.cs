using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade_Button : MonoBehaviour {

    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
    }

        private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
