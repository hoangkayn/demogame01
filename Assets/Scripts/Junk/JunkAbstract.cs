using UnityEngine;
using System.Collections;

public abstract  class JunkAbstract : BaseMonoBehaviour
{
    [SerializeField] protected JunkCtrl junkCtrl;
    public JunkCtrl JunkCtrl { get => junkCtrl; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();

    }
}

