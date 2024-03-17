using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    protected override void Start()
    {
       // Invoke(nameof(Test), 8);
    }
    private void Test()
    {
        DropItemIndex(0);
    }
    protected virtual bool DropItemIndex(int itemIndex)
    {
        if (itemIndex > this.inventory.ListItems.Count) return false;   
        ItemInventory itemInventory = this.inventory.ListItems[itemIndex];

        Vector3 dropPos = transform.parent.position;
        dropPos.x += 1;
        DropItemSpawner.Instance.DropFromInventory(itemInventory, dropPos, transform.parent.rotation);
        this.inventory.ListItems.Remove(itemInventory);
        return true;
    }
}
