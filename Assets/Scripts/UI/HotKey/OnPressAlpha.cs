using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPressAlpha : UIHotKeyAbstract
{
   protected virtual void Update()
    {
        this.CheckAlphaIsPress();
    }
    protected virtual void CheckAlphaIsPress()
    {
        if (InputHotKeyManager.Instance.isAlpha1) Press(1);
        if (InputHotKeyManager.Instance.isAlpha2) Press(2);
        if (InputHotKeyManager.Instance.isAlpha3) Press(3);
        if (InputHotKeyManager.Instance.isAlpha4) Press(4);
        if (InputHotKeyManager.Instance.isAlpha5) Press(5);
        if (InputHotKeyManager.Instance.isAlpha6) Press(6);
        if (InputHotKeyManager.Instance.isAlpha7) Press(7);

    }
    protected virtual void Press(int alpha)
    {
        ItemSlot itemSlot = this.uIHotKeyCtrl.ItemSlots[alpha - 1];
        PressAbility pressable = itemSlot.GetComponentInChildren<PressAbility>();
        if (pressable == null) return;
        pressable.Press();
    }
}
