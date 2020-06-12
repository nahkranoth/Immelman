using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using Unity.Collections.LowLevel.Unsafe;
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
    void FireBullet(Vector3 position, Quaternion orientation, Vector3 baseVelocity)
    {
        GameController.instance.FireBulletFrom(position, orientation, baseVelocity);
    }

    public void SendFireBullet(Vector3 position, Quaternion orientation, Vector3 baseVelocity)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("FireBullet", RpcTarget.Others, position, orientation, baseVelocity);
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
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
