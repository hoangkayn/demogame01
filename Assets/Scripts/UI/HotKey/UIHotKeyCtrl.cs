using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKeyCtrl : BaseMonoBehaviour
{
    private static UIHotKeyCtrl instance;
    public static UIHotKeyCtrl Instance { get => instance; }
    [SerializeField] protected List<ItemSlot> itemSlots;
    public List<ItemSlot> ItemSlots => itemSlots;

    protected override void Awake()
    {
        if (UIHotKeyCtrl.instance != null) Debug.LogError("Only 1 UIHotKeyCtrl allow to exist");
        UIHotKeyCtrl.instance = this;
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadItemSlots();
    }
    protected virtual void LoadItemSlots()
    {
        if (itemSlots.Count > 0) return;
        ItemSlot[] array = transform.GetComponentsInChildren<ItemSlot>();
        this.itemSlots.AddRange(array);
    }
}
