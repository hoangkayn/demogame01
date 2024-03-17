using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
   public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
     
        ItemInventory itemInventory = itemPickupable.DropItemCtrl.ItemInventory;
        if (playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
