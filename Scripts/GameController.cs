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
    public Vector3 startPosition = new Vector3(0f, 3000f, 0f);

    private void Awake()
    {
        instance = this;
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
    }

    public void UnregisterOtherPlayerAirplane(Player player)
    {
        UIController.instance.UnregisterTarget(otherPlayersToAirplanes[player].myTarget);
        otherPlayersToAirplanes.Remove(player);
    }

    public void RespawnAirplane()
    {
        ownPlane.CallResetMe();
    }

    public void FireBulletFrom(Vector3 position, Quaternion orientation, Vector3 baseVelocity)
    {
        var newbullet = Instantiate(bulletPrefab, position, orientation, bulletPoolContainer);
        var newBulletController = newbullet.GetComponent<BulletController>();
        newBulletController.Fire(position, orientation, baseVelocity);
    }
}
