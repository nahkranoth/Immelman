using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartScreenController : MonoBehaviour
{
    public TMP_InputField nicknameInput;

    public void Start()
    {
        nicknameInput.text = "Random Name";
    }
    public void OnStartGame()
    {
        NetworkManager.instance.StartGame(nicknameInput.text);
        gameObject.SetActive(false);
    }
}
