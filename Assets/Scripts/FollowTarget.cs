    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : BaseMonoBehaviour
{
    [SerializeField] float speedCam = 2f;
    [SerializeField] Transform target;
    // Start is called before the first frame update
   protected virtual void FixedUpdate()
    {
        Following();
    }
    protected virtual void Following()
    {
        if (target == null) return;
        transform.position = Vector3.Lerp(transform.position, target.position, Time.fixedDeltaTime  * speedCam);
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
}
