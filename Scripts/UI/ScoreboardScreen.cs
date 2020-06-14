using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class ScoreboardScreen : MonoBehaviour
{
    public GameObject playerScorePanel;

    public void HideList()
    {
        gameObject.SetActive(false);
    }
    public void ShowList()
    {
        gameObject.SetActive(true);

        Player[] players = PhotonNetwork.PlayerList;

        for(var i=0; i<transform.childCount-1;i++)
        {
            GameObject.Destroy(transform.GetChild(i+1).gameObject);
        }

        foreach (Player player in players)
        {
            ScoreboardPlayerPanel panel = GameObject.Instantiate(playerScorePanel, transform).GetComponent<ScoreboardPlayerPanel>();
            panel.Initiliaze(player.NickName, player.CustomProperties["kills"].ToString(), player.CustomProperties["deaths"].ToString());
        }
    }
}
