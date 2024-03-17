using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectMovement : BaseMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;
   
    [SerializeField] protected float distance = 1;
    [SerializeField] protected float minDistance = 1;
    // Start is called before the first frame update
    protected virtual void FixedUpdate()
    {
        Moving();
    }

   

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.parent.position, targetPosition);
        if (distance < minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
    public virtual void SetSpeed(float speed) {
        this.speed = speed;
    }

}
