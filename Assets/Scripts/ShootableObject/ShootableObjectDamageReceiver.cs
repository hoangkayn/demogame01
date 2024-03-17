using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectDamageReceiver: DamageReceiver
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
        shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        shootableObjectCtrl.Despawn.DespawnObject();
        this.OnDeadDrop();
    }
    protected virtual void OnDeadFX()
    {

        string fxName = this.GetFXName();
        Transform fxOndead = FXSpawner.Instance.Spawn(fxName, transform.parent.position, transform.parent.rotation);
        fxOndead.gameObject.SetActive(true);
    }
    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.parent.position;
        Quaternion dropRot = transform.parent.rotation;
        DropItemSpawner.Instance.Drop(shootableObjectCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
    }
    protected virtual string GetFXName()
    {
        return FXSpawner.Instance.SmokeOne;
    }
    protected override void Reborn()
    {
        this.maxHp = shootableObjectCtrl.ShootableObjectSO.maxHp;
        base.Reborn();
    }
}
