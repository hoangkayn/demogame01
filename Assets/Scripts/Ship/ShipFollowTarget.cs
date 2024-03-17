using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowTarget : ObjectMovement
{
    [SerializeField] protected Transform target;
    protected override void FixedUpdate()
    {
        this.GetPosTarget();
        base.FixedUpdate();
    }
    public virtual void SetTarget( Transform target)
    {
        this.target = target;
    }
    protected virtual void GetPosTarget() {
        targetPosition = this.target.position;
        targetPosition.z = 0;
    }

}
