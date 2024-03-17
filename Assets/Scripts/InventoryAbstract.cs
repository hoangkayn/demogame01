using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryAbstract : BaseMonoBehaviour
{
    [SerializeField] protected Inventory inventory;
    public Inventory Inventory { get => inventory; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadInventory();
    }
    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = transform.parent.GetComponent<Inventory>();
    }
}

