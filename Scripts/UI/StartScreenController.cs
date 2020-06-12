using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenController : MonoBehaviour
{
    public TMP_InputField nicknameInput;
    public TMP_Text footer;
    public Button startButton;

    private const string birdnamesPath = "Assets/Resources/birdnames.csv";

    public void Start()
    {
        string birdname = GetBirdName();
        nicknameInput.text = birdname;
        footer.text = string.Format("Version {0}", Application.version);
        gameObject.SetActive(true);
        startButton.interactable = false;
    }

    public void EnableJoinButton()
    {
        startButton.interactable = true;
    }

    public void OnStartGame()
    {
        NetworkManager.instance.StartGame(nicknameInput.text);
        gameObject.SetActive(false);
    }

    private string GetBirdName()
    {
        string result = "";

        var max = TotalLines(birdnamesPath);
        int randomLine = Random.Range(0, max);

        try
        {
            using (StreamReader inputFile = new StreamReader(birdnamesPath))
            {
                for (int i = 1; i <= randomLine; i++)
                {
                    inputFile.ReadLine();
                }

                result = inputFile.ReadLine();

            }
        }
        catch (IOException e)
        {
            Debug.LogWarning("Error in reading birdnames. Whaaah! Birdup! ...SpRiTe...");
        }
        return result;
    }

    private int TotalLines(string filePath)
    {
        using (StreamReader r = new StreamReader(filePath))
        {
            int i = 0;
            while (r.ReadLine() != null) { i++; }
            return i;
        }
    }

}

