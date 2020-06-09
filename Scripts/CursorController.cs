using UnityEngine;
using System.Collections;

public class CursorController:MonoBehaviour
{
    public static CursorController instance;

    private bool forced = false;

    private void Awake()
    {
        instance = this;
    }
    //TODO Transactions to keep track of who forced it
    public void ForceShow()
    {
        forced = true;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void ForceHide()
    {
        forced = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void RequestShow()
    {
        if (forced) return;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void RequestHide()
    {
        if (forced) return;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
