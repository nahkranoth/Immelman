using UnityEngine;

public class AirplaneWingController : MonoBehaviour
{
    public ControlSurface elevator;
    public ControlSurface aileronLeft;
    public ControlSurface aileronRight;
    public ControlSurface rudder;
    public SimpleWing wing;
    public SimpleWing bodyHor;
    public SimpleWing bodyVert;
    public SimpleWing rudderWing;
    public SimpleWing elevatorWing;
    public SimpleWing aileronLeftWing;
    public SimpleWing aileronRighttWing;

    public Engine engine;
    public Rigidbody rigid;

    public bool active;

    public void Awake()
    {
        DeactivateWings();
    }

    public void DeactivateWings()
    {
        elevator.active = false;
        aileronLeft.active = false;
        aileronRight.active = false;
        rudder.active = false;
        wing.active = false;
        bodyHor.active = false;
        bodyVert.active = false;
        rudderWing.active = false;
        elevatorWing.active = false;
        aileronRighttWing.active = false;
        aileronLeftWing.active = false;
        active = false;
    }
    public void ActivateWings()
    {
        elevator.active = true;
        aileronLeft.active = true;
        aileronRight.active = true;
        rudder.active = true;
        wing.active = true;
        bodyHor.active = true;
        bodyVert.active = true;
        rudderWing.active = true;
        elevatorWing.active = true;
        aileronRighttWing.active = true;
        aileronLeftWing.active = true;
        active = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!active) return;
        elevator.targetDeflection = -Input.GetAxis("Vertical");
        aileronLeft.targetDeflection = -Input.GetAxis("Horizontal");
        aileronRight.targetDeflection = Input.GetAxis("Horizontal");
        rudder.targetDeflection = Input.GetAxis("Yaw");

        var negativeThrottle = 1f - engine.throttle;

        var turn = new Vector3(Input.GetAxis("Vertical"), 0f, -Input.GetAxis("Horizontal")) * negativeThrottle * 200000f;
        rigid.AddRelativeTorque(turn, ForceMode.Force);

    }
}
