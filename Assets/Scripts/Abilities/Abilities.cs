using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public  class Abilities : BaseMonoBehaviour
{
    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl AbilityObjectCtrl { get => abilityObjectCtrl; }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilityObjectCtrl();
    }
    protected virtual void LoadAbilityObjectCtrl() {
        if (abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();

    }
    
}
