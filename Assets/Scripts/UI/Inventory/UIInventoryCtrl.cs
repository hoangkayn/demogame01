using UnityEngine;
using System.Collections;

public class UIInventoryCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform content;
    public Transform Content => content;
	[SerializeField] protected UIInventorySpawner uIInventorySpawner;
    public UIInventorySpawner UIInventorySpawner => uIInventorySpawner;
   
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadContent();
        this.LoadUIInventorySpawner();
    }
    protected virtual void LoadUIInventorySpawner()
    {
        if (this.uIInventorySpawner != null) return;
        this.uIInventorySpawner = transform.GetComponentInChildren<UIInventorySpawner>();
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
}

