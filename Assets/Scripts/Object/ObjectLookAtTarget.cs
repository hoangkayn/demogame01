using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ObjectLookAtTarget : BaseMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;

    [SerializeField] protected float rotSpeed = 3f;

    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {


        LookAtTarget();

    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float timeSpeed = Time.fixedDeltaTime * rotSpeed;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
    }

    public virtual void SetRotSpeed(float rotSpeed) {
        this.rotSpeed = rotSpeed;
    }
    

}
