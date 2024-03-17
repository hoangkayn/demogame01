using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipModify : ObjectModifyAbstract
{
    [Header("Mother Ship Modify")]
    [SerializeField] protected float speed = 0.005f;
    [SerializeField] protected float rotSpeed =1f;
    protected override void Start()
    {
        this.ShipModify();

        
    }













    protected virtual void ShipModify()
    {
        this.ShootableObjectCtrl.ObjectLookAtTarget.SetRotSpeed(rotSpeed);
        this.ShootableObjectCtrl.ObjectMovement.SetSpeed(speed);
    }
}
