using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : DropItemAbstract
{
    
    [SerializeField] protected SphereCollider _collider;
    protected static ItemCode StringToItemCode(string itemName) {
        return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
    }

    protected override void LoadComponent()
    {
        
        base.LoadComponent();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.03f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }
    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.StringToItemCode(transform.parent.name);
    }
    protected virtual void OnMouseDown()
    {
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }
    public virtual void Picked()
    {
        DropItemCtrl.IronItemDespawn.DespawnObject();
}

}
