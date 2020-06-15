using UnityEngine;
using System.Collections;

public class CursorController:MonoBehaviour
{
    public static CursorController instance;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Confined;
    }
    //TODO Transactions to keep track of who forced it
    public void ForceShow()
    {
        Cursor.visible = true;
    }

    public void ForceHide()
    {
        Cursor.visible = false;
    }

}
