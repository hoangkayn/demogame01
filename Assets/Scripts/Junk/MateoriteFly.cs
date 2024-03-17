using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MateoriteFly : ParentFly
{
    protected override void ResetValue()
    {
        base.ResetValue();
        moveSpeed = 0.5f;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.GetFlyDirection();
    }
    protected virtual void GetFlyDirection()
    {
        Vector3 camPos = GameCtrl.Instance.mainCarema.transform.position;
        Vector3 objPos = transform.parent.position;
        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rot_z);
        Debug.DrawLine(objPos, objPos + diff * 7, Color.green, Mathf.Infinity);
    }
        
}
