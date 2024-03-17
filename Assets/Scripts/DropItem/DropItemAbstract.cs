using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemAbstract : BaseMonoBehaviour
{
    [SerializeField] protected DropItemCtrl dropItemCtrl;
    public DropItemCtrl DropItemCtrl { get => dropItemCtrl; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadDropItemCtrl();
    }
    protected virtual void LoadDropItemCtrl()
    {
        if (dropItemCtrl != null) return;
        dropItemCtrl = transform.parent.GetComponent<DropItemCtrl>();

    }
}
