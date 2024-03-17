using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIInventorySpawner : Spawner
{
    private static UIInventorySpawner instance;
    public static UIInventorySpawner Instance { get => instance; }
    [SerializeField] protected UIInventoryCtrl UIInventoryCtrl;
    public static string UIInvItem = "UIInvItem";
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
    protected override void LoadComponent()
    {
        this.LoadUIInventoryCtrl();
        base.LoadComponent();
        
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.UIInventoryCtrl != null) return;
        this.UIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
    }
    protected override void LoadHolder()
    {
        if (holder != null) return;
        holder = this.UIInventoryCtrl.Content;
        Debug.Log(transform.name + ": LoadHolder", gameObject);
    }
    public virtual void ClearItem()
    {
        foreach(Transform item in holder)
        {
            Despawn(item);
        }
    }
    public virtual void SpawnItem(ItemInventory item)
    {
        Transform UIInvItem = UIInventorySpawner.Instance.Spawn(UIInventorySpawner.UIInvItem, Vector3.zero, Quaternion.identity);
        UIInvItem.transform.localScale = new Vector3(1, 1, 1);
        UIItemInventory uIItemInventory = UIInvItem.GetComponent<UIItemInventory>();
        uIItemInventory.ShowItem(item);
        UIInvItem.gameObject.SetActive(true);
    }
}

