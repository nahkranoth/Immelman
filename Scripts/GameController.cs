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
    public Airplane ownPlane;

    public Vector3 startPosition = new Vector3(0f, 3000f, 0f);

    private void Awake()
    {
        instance = this;
    }

    public void PlayerAirplaneInit(Airplane ownPlane)
    {
        this.ownPlane = ownPlane;
        UIController.instance.SetCamera(ownPlane.camera);
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
