using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected Rigidbody _rigibody;
    [SerializeField] protected SphereCollider sphereCollider;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigibody();
        this.LoadSphereCollider();
      
    }
   
    protected virtual void LoadRigibody()
    {
        if (_rigibody != null) return;
        _rigibody = GetComponent<Rigidbody>();
        _rigibody.isKinematic = true;
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0.26f;
        sphereCollider.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
       
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;
        ItemInventory itemInventory = itemPickupable.DropItemCtrl.ItemInventory;
        if (this.inventory.AddItem(itemInventory)) {
            itemPickupable.Picked();
        }

    }
}
