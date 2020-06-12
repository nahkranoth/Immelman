using TMPro;
using UnityEngine;

public class ScoreboardPlayerPanel : MonoBehaviour
{
    public TextMeshProUGUI name;
    public TextMeshProUGUI kills;
    public TextMeshProUGUI deaths;

    public void Initiliaze(string _name, string _kills, string _deaths)
    {
        name.text = _name;
        kills.text = _kills;
        deaths.text = _deaths;
    }
}
