using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : BaseMonoBehaviour
{

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    [SerializeField] protected TextMeshProUGUI itemName;
    public TextMeshProUGUI ItemName => itemName;
    [SerializeField] protected TextMeshProUGUI itemCount;
    public TextMeshProUGUI ItemCount => itemCount;

    [SerializeField] protected Image imageItem;
    public Image ImageItem => imageItem;

    protected override void LoadComponent()
    {
        base.LoadComponent();
     
        this.LoadItemName();
        this.LoadItemCount();
        this.LoadImageItem();
    }
   
    protected virtual void LoadItemName()
    {
        if (itemName != null) return;
        itemName = transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadItemCount()
    {
        if (itemCount != null) return;
        itemCount = transform.Find("ItemCount").GetComponent<TextMeshProUGUI>();
    }
    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;  
        this.itemName.text = item.itemProfileSO.itemName;
        this.itemCount.text = item.itemCount.ToString();
        this.imageItem.sprite = item.itemProfileSO.sprite;
    }
    protected virtual void LoadImageItem()
    {
        if (this.imageItem != null) return;
        this.imageItem = transform.Find("ImageItem").GetComponent<Image>();
    }

}
