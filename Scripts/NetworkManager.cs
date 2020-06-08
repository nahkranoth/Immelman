using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance;
    public GameObject plane;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
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
        GameController.instance.ownPlane = PhotonNetwork.Instantiate(this.plane.name, GameController.instance.startPosition, Quaternion.identity, 0).GetComponent<Airplane>();
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
