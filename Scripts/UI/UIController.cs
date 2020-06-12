using System;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Canvas canvas;
    public GameObject resetButton;
    public Dictionary<Target, RectTransform> trackerTargets = new Dictionary<Target, RectTransform>();
    public GameObject trackerPrefab;
    public Target testTarget;
    public RectTransform throttleIndicator;

    public GameObject incorrectVersionScreen;
    public ScoreboardScreen scoreBoardScreen;
    public StartScreenController startScreen;

    public void ShowIncorrectVersionScreen()
    {
        incorrectVersionScreen.SetActive(true);
    }
    public void ShowScoreboardScreen()
    {
        scoreBoardScreen.ShowList();
        scoreBoardScreen.gameObject.SetActive(true);
    }
    public void HideScoreboardScreen()
    {
        scoreBoardScreen.gameObject.SetActive(false);
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

    private void Awake()
    {
        instance = this;
    }

    public void ToggleResetButton(Boolean force)
    {
        resetButton.SetActive(force);
    }

    public void OnResetPressed()
    {
        GameController.instance.RespawnAirplane();
    }

}
