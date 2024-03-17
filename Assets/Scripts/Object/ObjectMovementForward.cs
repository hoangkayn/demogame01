using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ObjectMovementForward: ObjectMovement
{
    [SerializeField] protected Transform targetForward;
    public Transform TargetForward { get => targetForward; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadTargetForward();
    }
    protected override void FixedUpdate()
    {
        this.GetTargetForward();
        Moving();
      

    }

   protected virtual void GetTargetForward()
    {
        this.targetPosition = this.targetForward.position;
        this.targetPosition.z = 0;
    }

    protected virtual void LoadTargetForward() {
        if (this.targetForward != null) return;
        this.targetForward = transform.Find("TargetForward");
    }



}
