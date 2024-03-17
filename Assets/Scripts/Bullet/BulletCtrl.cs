using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : BaseMonoBehaviour
{
    [Header("BulletCtrl")]
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender { get => bulletDamageSender; }

    [SerializeField] protected BulletDespawns bulletDespawns;
    public BulletDespawns BulletDespawns { get => bulletDespawns; }

    [SerializeField] protected Transform shooter;
    public Transform Shooter { get => shooter; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadBulletDamageSender();
        LoadBulletDespawns();

    }
    protected virtual void LoadBulletDamageSender()
    {
        if (bulletDamageSender != null) return;
        bulletDamageSender = transform.Find("DamageSender").GetComponent<BulletDamageSender>();

    }
    protected virtual void LoadBulletDespawns()
    {
        if (bulletDespawns != null) return;
        bulletDespawns = transform.Find("Despawn").GetComponent<BulletDespawns>();

    }
    public virtual void SetShooter(Transform transform) {
        this.shooter = transform;
    }

}
