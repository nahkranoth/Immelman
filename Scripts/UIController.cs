using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackerTargetPair
{
    public Target target;
    public RectTransform tracker;

    public TrackerTargetPair(Target _target, RectTransform _tracker)
    {
        target = _target;
        tracker = _tracker;
    }
}

public class UIController : MonoBehaviour
{
    public static UIController instance;
    public Canvas canvas;
    public GameObject resetButton;
    public List<TrackerTargetPair> trackerTargets = new List<TrackerTargetPair>();
    public GameObject trackerPrefab;
    public Target testTarget;

    public void SetCamera()
    {
        canvas.worldCamera = Camera.main;
        RegisterTarget(testTarget);
    }

    public void RegisterTarget(Target target)
    {
        var tracker = Instantiate(trackerPrefab, canvas.transform).GetComponent<RectTransform>();
        var trackerTarget = new TrackerTargetPair(target, tracker);
        trackerTargets.Add(trackerTarget);
    }

    private void Update()
    {
        if (!Camera.main) return;
        foreach (var pair in trackerTargets)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(pair.target.transform.position);
            pair.tracker.anchoredPosition = new Vector3(screenPos.x, screenPos.y, 0f);
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
    
    public void ToggleResetButton()
    {
        resetButton.SetActive(!resetButton.activeSelf);
    }

    public void OnResetPressed()
    {
        GameController.instance.RespawnAirplane();
    }

}
