using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbstract : BaseMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl { get => playerCtrl; }


    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPlayerCtrl();
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();

    }
}
