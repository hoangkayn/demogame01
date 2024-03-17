using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : ObjectMovement
{

    protected override void FixedUpdate()
    {
        this.GetPosMouse();
        base.FixedUpdate();
    }
    protected virtual void GetPosMouse()
    {
        targetPosition = InputManager.Instance.MousePosition;
        targetPosition.z = 0;
    }
}
