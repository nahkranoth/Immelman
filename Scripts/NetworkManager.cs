﻿using Photon.Pun;
using Photon.Realtime;
using System;
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

    [PunRPC]
    void ChatMessage(string a, string b)
    {
        Debug.Log(string.Format("ChatMessage {0} {1}", a, b));
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

    public void SendJoinMessage()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ChatMessage", RpcTarget.All, "jup", "and jup.");
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    /*public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        base.OnPlayerPropertiesUpdate(targetPlayer, changedProps);
    }*/

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
        CreateRoom("testroom");
        Debug.Log("connected");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        GameController.instance.PlayerAirplaneInit(PhotonNetwork.Instantiate(this.plane.name, GameController.instance.startPosition, Quaternion.identity, 0).GetComponent<Airplane>());
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
