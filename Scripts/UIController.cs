using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject resetButton;

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
