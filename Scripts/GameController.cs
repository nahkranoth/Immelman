using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviourPun
{
    public int bulletPoolAmount;
    public GameObject bulletPrefab;
    public Transform bulletPoolContainer;
    public static GameController instance;
    public Dictionary<Player, Airplane> playerAirplanes = new Dictionary<Player, Airplane>();

    private void Awake()
    {
        instance = this;
    }

    public void FireBulletFrom(Vector3 position, Quaternion orientation, Vector3 baseVelocity)
    {
        var newbullet = Instantiate(bulletPrefab, position, orientation, bulletPoolContainer);
        var newBulletController = newbullet.GetComponent<BulletController>();
        newBulletController.Fire(position, orientation, baseVelocity);
    }
}
