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

    private void Update()
    {
        if (throttle) engine.ChangeThrottle(throttleAmount);

        //TODO: Need camera values for freelook
        if (freeLook) {
        }
    }


    public void OnBoost(InputAction.CallbackContext context)
    {
        if (context.started) airplane.StartBoost();
        if (context.canceled) airplane.EndBoost();
    }

    public void OnFreeLook(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            GameController.instance.cameraController.lookAt = false;
            freeLook = true;
        }else if (context.canceled)
        {
            GameController.instance.cameraController.lookAt = true;
            freeLook = false;
        }
    }

    public void OnMoving(InputAction.CallbackContext context)
    {
        airplaneWingController.SetPitchRollDeflection(context.ReadValue<Vector2>());
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
}
