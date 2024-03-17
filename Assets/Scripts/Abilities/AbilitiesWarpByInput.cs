using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitiesWarpByInput:AbilityWarp{
    protected override void Update()
    {
        base.Update();
        this.UpdateDirection();

    }
    protected virtual void UpdateDirection() {
        this.keyDirection = InputManager.Instance.Direction;
    }

}
