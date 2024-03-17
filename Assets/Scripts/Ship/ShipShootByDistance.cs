using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByDistance : ObjectShooting

{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float minDistance = 3f;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(transform.parent.position, target.transform.position);

        isShooting = this.distance < minDistance;
        return isShooting;
    }
}
