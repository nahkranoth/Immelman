using UnityEngine;
using UnityEngine.InputSystem;

public class AirplaneInputController : MonoBehaviour, MainInput.IAirplaneActions
{
    public Airplane airplane;
    public Engine engine;
    public AirplaneWingController airplaneWingController;
    public bool active = true;

    private bool throttle;
    private float throttleAmount = .1f;
    private float throttleIntensity = 0.04f;

    private bool freeLook = false;
    private Vector2 mousePosition = Vector2.zero;



    private void Update()
    {
        if (throttle) engine.ChangeThrottle(throttleAmount);

        //TODO: Need camera values for freelook
        if (freeLook) {
            GameController.instance.cameraController.RotateCamera(Mouse.current.position.ReadValue(), transform.position);
        }
    }


    public void OnBoost(InputAction.CallbackContext context)
    {
        if (context.started) engine.Boost();
        if (context.canceled) engine.EndBoost();
    }

    public void OnFreeLook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameController.instance.cameraController.StartRotate();
            freeLook = true;
        }else if (context.canceled)
        {
            GameController.instance.cameraController.StopRotate();
            freeLook = false;
        }
    }

    public void OnMoving(InputAction.CallbackContext context)
    {
        bool enabled = context.started;
        if(!context.started && !context.canceled) enabled = true;
        airplaneWingController.SetPitchRollDeflection(context.ReadValue<Vector2>(), enabled);
    }

    public void OnYawMoving(InputAction.CallbackContext context)
    {
        airplaneWingController.SetYawDeflection(context.ReadValue<float>());
    }

    public void OnShoot(InputAction.CallbackContext context)
    {
        if(context.started) airplane.ToggleGun(true);
        if(context.canceled) airplane.ToggleGun(false);
    }

    public void OnThrottle(InputAction.CallbackContext context)
    {
        throttleAmount = context.ReadValue<float>() * throttleIntensity;
        if (context.started) throttle = true;
        if (context.canceled) throttle = false;
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        if (context.started) airplane.ToggleBrake(true);
        if (context.canceled) airplane.ToggleBrake(false);
    }

    public void OnMouseLook(InputAction.CallbackContext context)
    {
        Debug.Log(" On Mouse Look ");
        mousePosition = context.ReadValue<Vector2>();
    }
}
