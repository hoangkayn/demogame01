using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCtrl : BaseMonoBehaviour
{
 
    [SerializeField] protected IronItemDespawn ironItemDespawn;
    public IronItemDespawn IronItemDespawn { get => ironItemDespawn; }

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory { get => itemInventory; }



    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadIronItemDespawn();
        this.LoadItemInventory();
       
    }
   

    protected virtual void OnDisable()
    {
        
        this.ResetItem();
    }
    protected virtual void ResetItem()
    {
        this.itemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
    protected virtual void LoadIronItemDespawn()
    {
        if (ironItemDespawn != null) return;
        ironItemDespawn = transform.Find("Despawn").GetComponent<IronItemDespawn>();
    }
    public void SetItemInventory(ItemInventory itemPicked)
    {
        this.itemInventory = itemPicked.Clone();
    }
    protected virtual void LoadItemInventory() {
        if (itemInventory.itemProfileSO  != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfileSO = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfileSO = itemProfileSO;
        ResetItem();
    }

}
