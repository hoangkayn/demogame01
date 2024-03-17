using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : UIInventoryAbstract
{

    private static UIInventory instance;
    public static UIInventory Instance { get => instance; }
    [SerializeField] protected bool isOpen = false;
    [SerializeField] protected InventorySort inventorySort = InventorySort.NoItem;
    protected override void Awake()
    {
        base.Awake();
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected override void Start()
    {
        base.Start();
        this.Close();
        InvokeRepeating(nameof(this.ShowItems), 1, 1);
    }
    protected virtual void FixedUpdate()
    {
        // this.ShowItems();
    }
    protected virtual void ShowItems()
    {
        if (!this.isOpen) return;
        this.ClearItem();
        List<ItemInventory> listItems = PlayerCtrl.Instance.CurrentShip.Inventory.ListItems;
        UIInventorySpawner spawner = UIInventoryCtrl.UIInventorySpawner;
        foreach (ItemInventory item in listItems)
        {
            spawner.SpawnItem(item);
        }
        this.SortItems();
    }
    protected virtual void ClearItem()
    {
        UIInventoryCtrl.UIInventorySpawner.ClearItem();
    }
    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (isOpen)
        {
            this.Open();
        }
        else
        {
            this.Close();
        }

    }
    public virtual void Open()
    {
        UIInventoryCtrl.gameObject.SetActive(true);
    }
    public virtual void Close()
    {
        UIInventoryCtrl.gameObject.SetActive(false);
    }

    protected virtual void SortItems()
    {
        switch (this.inventorySort)
        {
            case InventorySort.ByName:
                this.SortByName();

                break;
            case InventorySort.ByCount:
                Debug.Log("InventorySort.ByCount");
                break;
            default:
                Debug.Log("InventorySort.NoItem");
                break;
        }
    }
    protected virtual void SortByName()
    {
        Debug.Log("InventorySort.ByName");
        int itemCount = UIInventoryCtrl.Content.childCount;
        bool isSorting = false;
        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem, nextItem;
            UIItemInventory currentUIItemInv, nextUIItemInv;
            ItemProfileSO currentPro, nextPro;
            string currentName, nextName;
            currentItem = UIInventoryCtrl.Content.GetChild(i);
            nextItem = UIInventoryCtrl.Content.GetChild(i + 1);
            currentUIItemInv = currentItem.GetComponent<UIItemInventory>();
            nextUIItemInv = nextItem.GetComponent<UIItemInventory>();
            currentPro = currentUIItemInv.ItemInventory.itemProfileSO;
            nextPro = nextUIItemInv.ItemInventory.itemProfileSO;
            currentName = currentPro.itemName;
            nextName = nextPro.itemName;
            int compare = string.Compare(currentName, nextName);
            if (compare == 1)
            {
                this.SwapItem(currentItem, nextItem);
                isSorting = true;
            }

            Debug.Log(i + ": " + currentName + " | " + nextName + " = " + compare);

        }
        if (isSorting) this.SortByName();
    }
    protected virtual void SwapItem(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
