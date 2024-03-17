using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectModifyAbstract : BaseMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectCtrl { get => shootableObjectCtrl; }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadShootableObjectCtrl();
    }
    protected virtual void LoadShootableObjectCtrl()
    {
        if (shootableObjectCtrl != null) return;
        shootableObjectCtrl = GetComponent<ShootableObjectCtrl>();
    }
}

