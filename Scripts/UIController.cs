using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Canvas canvas;
    public GameObject resetButton;

    public void SetCamera(Camera camera)
    {
        canvas.worldCamera = camera;
    }

    private void Awake()
    {
        instance = this;
    }

    public void ToggleResetButton(Boolean force)
    {
        resetButton.SetActive(force);
    }
    
    public void ToggleResetButton()
    {
        resetButton.SetActive(!resetButton.activeSelf);
    }

    public void OnResetPressed()
    {
        GameController.instance.RespawnAirplane();
    }

}
