using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;


public class GlobalSettings
{
    public string version;
    public string windows_url;
    public string osx_url;
}
public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;
    public GameObject plane;
    public GlobalSettings globalSettings;
    private string versionurl = "http://joeyvanderkaaij.com/sharing/Immelman/version.json";

    private void Awake()
    {
        instance = this;
    }

    public void DownloadLatestVersion()
    {
        var url = Application.platform == RuntimePlatform.OSXPlayer ? globalSettings.osx_url : globalSettings.windows_url;
        Application.OpenURL(url);
    }

    IEnumerator Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        using (WWW www = new WWW(versionurl))//TODO What if it fails?
        {
            yield return www;
            string content = www.text;
            globalSettings = JsonUtility.FromJson<GlobalSettings>(content);
            if(globalSettings.version != Application.version)
            {
                UIController.instance.ShowIncorrectVersionScreen();
                CursorController.instance.ForceShow();
            }
        }
    }

    public void StartGame(string nickName)
    {
        PhotonNetwork.LocalPlayer.NickName = nickName;
        CreateRoom("testroom");
    }

    [PunRPC]
    void FireBullet(Vector3 position, Quaternion orientation, Vector3 baseVelocity, Player owner)
    {
        GameController.instance.FireBulletFrom(position, orientation, baseVelocity, owner);
    }

    public void SendFireBullet(Vector3 position, Quaternion orientation, Vector3 baseVelocity)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("FireBullet", RpcTarget.Others, position, orientation, baseVelocity, PhotonNetwork.LocalPlayer);
    }

    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.PublishUserId = true;
        PhotonNetwork.CreateRoom(roomName, options);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        GameController.instance.UnregisterOtherPlayerAirplane(otherPlayer);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create Room Failed");
        JoinRoom("testroom");
        base.OnCreateRoomFailed(returnCode, message);
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        PhotonNetwork.LocalPlayer.NickName = "Unknown Player";
        UIController.instance.startScreen.EnableJoinButton();
        Debug.Log("connected");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        base.OnJoinedRoom();
        GameController.instance.PlayerAirplaneInit(PhotonNetwork.Instantiate(this.plane.name, GameController.instance.startNode.position, Quaternion.identity, 0).GetComponent<Airplane>());
    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        Debug.Log("created room: " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnErrorInfo(ErrorInfo errorInfo)
    {
        base.OnErrorInfo(errorInfo);
        Debug.Log(errorInfo.Info);
    }
}
