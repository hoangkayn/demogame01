using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtMouse : ObjectLookAtTarget
{
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.MousePosition;
        this.targetPosition.z = 0;
    }
}
