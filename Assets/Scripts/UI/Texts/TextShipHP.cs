using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }
    protected virtual void UpdateShipHP() {
       
        int hpMax = PlayerCtrl.Instance.CurrentShip.DamageReceiver.MaxHP;
        int currentHP = PlayerCtrl.Instance.CurrentShip.DamageReceiver.CurrentHP;
        this.text.SetText(currentHP +" / " + hpMax);
    }

}
