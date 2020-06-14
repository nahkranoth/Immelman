using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIController : MonoBehaviour, MainInput.IUIActions
{
    public static UIController instance;
    public Canvas canvas;
    public GameObject resetButton;
    public Dictionary<Target, RectTransform> trackerTargets = new Dictionary<Target, RectTransform>();
    public GameObject trackerPrefab;
    public Target testTarget;
    public RectTransform throttleIndicator;
    public RectTransform boostIndicator;
    public RectTransform healthIndicator;
    private float startIndicatorWidth;

    public GameObject incorrectVersionScreen;
    public ScoreboardScreen scoreBoardScreen;
    public StartScreenController startScreen;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        startIndicatorWidth = boostIndicator.rect.width;
    }

    public void SetHealth(float normalizedValue)
    {
        //healthIndicator.rect.Set(healthIndicator.rect.x, healthIndicator.rect.y, startIndicatorWidth * normalizedValue, healthIndicator.rect.height);
    }

    public void SetBoost(float normalizedValue)
    {
        //boostIndicator.rect.Set(boostIndicator.rect.x, boostIndicator.rect.y, startIndicatorWidth * normalizedValue, boostIndicator.rect.height);
    }

    public void ShowIncorrectVersionScreen()
    {
        incorrectVersionScreen.SetActive(true);
    }

    public void SetCamera()
    {
        RegisterTarget(testTarget);
    }

    public RectTransform RegisterTarget(Target target)
    {
        var tracker = Instantiate(trackerPrefab, canvas.transform).GetComponent<RectTransform>();
        trackerTargets.Add(target, tracker);
        return tracker;
    }

    public void UnregisterTarget(Target target)
    {
        Destroy(trackerTargets[target].gameObject);
        trackerTargets.Remove(target);
    }

    private void Update()
    {
        if (!Camera.main) return;
        foreach (var pair in trackerTargets)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(pair.Key.transform.position);
            if (screenPos.z < 0f) continue;//check if target is behind camera
            pair.Value.anchoredPosition = new Vector3(screenPos.x, screenPos.y, 0f);
        }
    }

    public void ToggleResetButton(Boolean force)
    {
        resetButton.SetActive(force);
    }

    public void OnResetPressed()
    {
        GameController.instance.RespawnAirplane();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnToggleScoreboard(InputAction.CallbackContext context)
    {//TODO Can show on startscreen
        if (context.started) scoreBoardScreen.ShowList();
        if (context.canceled) scoreBoardScreen.HideList();
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        throw new NotImplementedException();
    }
}
