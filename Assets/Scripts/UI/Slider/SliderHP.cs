using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
    [SerializeField] float currentHP = 70f;
    public float CurreentHP { get => currentHP; }

    [SerializeField] float maxHP = 100f;
    public float MaxHP { get => maxHP; }
    protected override void OnChanged(float newValue)
    {
       //
    }
    protected virtual void FixedUpdate() {
        this.HPShowing();
    }
    protected virtual void HPShowing()
    {   
        float value = this.currentHP / this.maxHP;
        this.slider.value = value;
    }
    public virtual void SetCurrentHP(float value)
    {
        this.currentHP = value;
    }
    public virtual void SetMaxHP(float value)
    {
        this.maxHP = value;
    }
}
