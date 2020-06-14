using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsEyeHitDetector : MonoBehaviourPun
{
    public BirdsheadController birdHead;
    public Material standardMaterial;
    public Material enabledMaterial;
    public MeshRenderer meshRenderer;
    private bool isEnabled = false;

    [PunRPC]
    public void EnableMe()
    {
        if (isEnabled) return;
        isEnabled = true;
        birdHead.HitEye();
        meshRenderer.material = enabledMaterial;
    }

    public void OnCollisionEnter(Collision collision)
    {
        this.photonView.RPC("EnableMe", RpcTarget.All);
    }
}
