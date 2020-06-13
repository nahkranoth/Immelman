using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsEyeHitDetector : MonoBehaviour
{
    public BirdsheadController birdHead;
    public Material standardMaterial;
    public Material enabledMaterial;
    public MeshRenderer meshRenderer;
    public bool IsLeftEye;

    public void OnCollisionEnter(Collision collision)
    {
        birdHead.HitEye(IsLeftEye);
        meshRenderer.material = enabledMaterial;
    }
}
