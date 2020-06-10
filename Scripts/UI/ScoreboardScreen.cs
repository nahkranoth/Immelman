using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ScoreboardScreen : MonoBehaviour
{
    public GameObject playerScorePanel;

    public void ShowList()
    {
        Player[] players = PhotonNetwork.PlayerList;

        for(var i=0; i<transform.childCount-1;i++)
        {
            GameObject.Destroy(transform.GetChild(i+1).gameObject);
        }

        foreach (Player player in players)
        {
            ScoreboardPlayerPanel panel = GameObject.Instantiate(playerScorePanel, transform).GetComponent<ScoreboardPlayerPanel>();
            var cp = player.CustomProperties;
            panel.Initiliaze(player.NickName, "0", (string)cp["deaths"]);
        }
    }
}
