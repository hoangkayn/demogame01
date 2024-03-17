using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteRotate : JunkAbstract
{
    [SerializeField] protected float speed = 9f;
  
   protected virtual void FixedUpdate()
    {
        Rotating();
    }
    protected virtual void Rotating()
    {
        Vector3 eulers = Vector3.forward;
        junkCtrl.Model.Rotate(eulers, Time.fixedDeltaTime * speed);
    }
}
