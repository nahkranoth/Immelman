using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCubeController : MonoBehaviourPun
{
    public bool IsActive = false;

    // Update is called once per frame
    void Update()
    {
        if (this.photonView.IsMine == true && IsActive)
        {
            transform.position += Vector3.forward * 0.1f;
        }
    }
}
