using Photon.Pun;
using UnityEngine;
using UnityEngine.InputSystem;

public class AirplaneWingController : MonoBehaviourPun
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

    private bool applyingMoveControls;
    private Vector2 moveAxis;

    public void Awake()
    {
        DeactivateWings();
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        if (!active) return;
        if (!applyingMoveControls) return;

        var negativeThrottle = 1f - engine.throttle;
        var turn = new Vector3(moveAxis.y, 0f, -moveAxis.x) * negativeThrottle * 200000f;
        rigid.AddRelativeTorque(turn, ForceMode.Force);
    }

    public void SetPitchRollDeflection(Vector2 axis, bool enabled)
    {
        if (!active) return;
        applyingMoveControls = enabled;
        moveAxis = axis;
        elevator.targetDeflection = -axis.y;
        aileronLeft.targetDeflection = -axis.x;
        aileronRight.targetDeflection = axis.x;
    }

    public void SetYawDeflection(float value)
    {
        rudder.targetDeflection = value;
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
}
