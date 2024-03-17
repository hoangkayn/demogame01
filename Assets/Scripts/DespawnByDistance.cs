using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distance;
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected Transform mainCam;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCamera();

    }

    protected virtual void LoadCamera()
    {
        if (mainCam != null) return;
        mainCam = GameObject.Find("Main Camera").transform;
    }

    protected override bool CanDespawn()
    {
        distance = Vector3.Distance(transform.parent.position,mainCam.position);
        if (distance > disLimit) return true;
        return false;
    }
   
}
