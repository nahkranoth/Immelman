using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageHit 
{
    float damage { get; }
    Player owner { get; set; }
}
