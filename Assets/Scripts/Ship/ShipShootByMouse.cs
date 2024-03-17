using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        isShooting = InputManager.Instance.OnFirting == 1;
        return isShooting;
    }
}
