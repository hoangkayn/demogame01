using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : BaseMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> listItems;
    public List<ItemInventory> ListItems { get => listItems; }
    protected override void Start()
    {
        base.Start();
        this.AddItem(ItemCode.IronItem, 3);
    }
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfileSO;
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;

        if (itemType == ItemType.Equiment) return this.AddEquiment(itemInventory);
        return this.AddItem(itemCode, addCount);
    }

    protected virtual bool AddEquiment(ItemInventory itemPicked)
    {
        if (this.IsInventoryFull()) return false;
        ItemInventory item = itemPicked.Clone();
        this.listItems.Add(item);
        return true;
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount)
    {

        ItemProfileSO itemProfile = this.GetItemProfile(itemCode);

        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        while (true)
        {

            itemExist = this.GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (this.IsInventoryFull()) return false;

                itemExist = this.CreateEmptyItem(itemProfile);
                this.listItems.Add(itemExist);
            }

            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = this.GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else
            {
                addRemain -= newCount;
            }

            itemExist.itemCount = newCount;
            if (addRemain < 1) break;

        }
        return true;
    }

    protected virtual bool IsInventoryFull()
    {
        if (this.listItems.Count >= this.maxSlot) return true;
        return false;
    }


    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;

        return itemInventory.maxStack;
    }

    protected virtual ItemProfileSO GetItemProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemInventory in this.listItems)
        {
            if (itemCode != itemInventory.itemProfileSO.itemCode) continue;
            if (this.IsFullStack(itemInventory)) continue;
            return itemInventory;
        }

        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;

        int maxStack = this.GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }

    protected virtual ItemInventory CreateEmptyItem(ItemProfileSO itemProfile)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemID = ItemInventory.RandomID(),
            itemProfileSO = itemProfile,
            maxStack = itemProfile.defaultMaxStack
        };

        return itemInventory;
    }

    public virtual  bool ItemCheck(ItemCode itemCode, int itemCount)
    {
        int totalCount = this.ItemTotalCount(itemCode);
        return totalCount >= itemCount;
    }

    protected virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory item in listItems)
        {
            if (item.itemProfileSO.itemCode != itemCode) continue;
            
                totalCount += item.itemCount;
            
        }
        return totalCount;
    }

    public virtual void Deduct(ItemCode itemCode, int itemCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for(int i = this.listItems.Count -1;i >= 0; i--)
        {
            if (itemCount <= 0) break;
            itemInventory = listItems[i];
            if (itemInventory.itemProfileSO.itemCode != itemCode) continue;
            if(itemInventory.itemCount < itemCount)
            {
                deduct = itemInventory.itemCount;
                itemCount -= itemInventory.itemCount;
            }
            else
            {
                deduct = itemCount;
                itemCount = 0;
               
            }
            itemInventory.itemCount -= deduct;
            
        }
        this.ClearEmptySlot();
    }

    protected virtual void ClearEmptySlot()
    {
        ItemInventory itemInventory;
        for(int i = 0;i< listItems.Count; i++)
        {
            itemInventory = listItems[i];
            if (itemInventory.itemCount != 0) continue;
            listItems.Remove(itemInventory);
        }
    }










    /*
    protected virtual bool AddResource(ItemInventory itemInventory, int addCount)
    {
        Debug.Log("AddResource");

        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool AddEquiment(ItemInventory itemInventory)
    {
        Debug.Log("AddEquiment");
        itemInventory.itemCount = 1;
        return true;
    }

    public virtual bool DeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if (newCount < 0) return false;

        itemInventory.itemCount = newCount;
        return true;
    }

    public virtual bool TryDeductItem(ItemCode itemCode, int addCount)
    {
        ItemInventory itemInventory = this.GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount - addCount;
        if (newCount < 0) return false;
        return true;
    }

    public virtual ItemInventory GetItemByCode(ItemCode itemCode)
    {
        ItemInventory itemInventory = this.items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = this.AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profile,
                maxStack = profile.defaultMaxStack
            };
            this.items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }

    */
}
