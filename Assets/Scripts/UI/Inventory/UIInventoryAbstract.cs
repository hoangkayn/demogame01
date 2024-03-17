using UnityEngine;
using System.Collections;

public abstract class UIInventoryAbstract: BaseMonoBehaviour
{
    [SerializeField] protected UIInventoryCtrl UIInventoryCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.UIInventoryCtrl != null) return;
        this.UIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();

    }
}

