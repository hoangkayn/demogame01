using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : BaseMonoBehaviour
{
    [SerializeField] protected int damage = 1;
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
            this.CreateImpactFX();
            this.Send(damageReceiver);
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = this.GetImpactFX();
        Transform prefab = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        prefab.gameObject.SetActive(true);

    }
    protected virtual string GetImpactFX()
    {
        return FXSpawner.Instance.Impact;
    }
}
