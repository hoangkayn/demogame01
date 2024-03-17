using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIHotKeyAbstract : BaseMonoBehaviour
{
    [SerializeField] protected UIHotKeyCtrl uIHotKeyCtrl;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIHotKeyCtrl();
    }
    protected virtual void LoadUIHotKeyCtrl()
    {
        if (this.uIHotKeyCtrl != null) return;
        this.uIHotKeyCtrl = transform.parent.GetComponent<UIHotKeyCtrl>();
    }
}
