using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : BaseMonoBehaviour
{
    [Header("BulletAbstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();

    }

}
