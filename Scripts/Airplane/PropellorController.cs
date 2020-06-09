using UnityEngine;
using System.Collections;

public class PropellorController : MonoBehaviour
{
    public Engine engine;
    private float topTurnSpeed = 10f;
    // Use this for initialization
  
    void Update()
    {
        transform.Rotate(Vector3.left * engine.throttle * topTurnSpeed);
    }
}
