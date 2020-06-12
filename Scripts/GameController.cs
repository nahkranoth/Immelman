using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviourPun
{
    public int bulletPoolAmount;
    public GameObject bulletPrefab;
    public Transform bulletPoolContainer;
    public static GameController instance;
    public Airplane ownPlane;
    public CameraController cameraController;
    public Dictionary<Player, Airplane> otherPlayersToAirplanes = new Dictionary<Player, Airplane>();
    public Dictionary<string, Player> otherPlayers = new Dictionary<string, Player>();
    public Transform startNode;
    public bool paused;

    private void Awake()
    {
        instance = this;
    }

    public Player GetPlayerById(string id)
    {
        if (id == PhotonNetwork.LocalPlayer.UserId) return PhotonNetwork.LocalPlayer;
        return otherPlayers[id];
    }

    public void PlayerAirplaneInit(Airplane ownPlane)
    {
        this.ownPlane = ownPlane;
        cameraController.Follow(ownPlane.cameraGimbal.transform, ownPlane.transform);
        UIController.instance.SetCamera();
    }

    public void RegisterOtherPlayerAirplane(Player player, Airplane airplane)
    {
        otherPlayersToAirplanes.Add(player, airplane);
        Debug.Log(player.UserId);
        otherPlayers.Add(player.UserId, player);
    }

    public void UnregisterOtherPlayerAirplane(Player player)
    {
        UIController.instance.UnregisterTarget(otherPlayersToAirplanes[player].myTarget);
        otherPlayersToAirplanes.Remove(player);
        otherPlayers.Remove(player.UserId);
    }

    public void RespawnAirplane()
    {
        ownPlane.CallResetMe();
    }

    public void FireBulletFrom(Vector3 position, Quaternion orientation, Vector3 baseVelocity, Player owner)
    {
        var newbullet = Instantiate(bulletPrefab, position, orientation, bulletPoolContainer);
        var newBulletController = newbullet.GetComponent<BulletController>();
        newBulletController.Fire(position, orientation, baseVelocity, owner);
    }
}
