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
        Cursor.visible = true;
    }

    public void ForceHide()
    {
        forced = false;
        Cursor.visible = false;
    }

    public void RequestHide()
    {
        if (forced) return;
        Cursor.visible = false;
    }

    public void RequestShow()
    {
        if (forced) return;
        Cursor.visible = true;
    }

}
