using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : BaseMonoBehaviour
{
    [SerializeField] protected Slider slider;



    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSlider();
    }
    protected override void Start()
    {
        base.Start();
        this.OnChangeValue();
    }
    protected virtual void LoadSlider()
    {
        if (this.slider != null) return;
        this.slider = GetComponent<Slider>();
    }
    protected virtual void OnChangeValue()
    {
        this.slider.onValueChanged.AddListener(this.OnChanged);
    }
    protected abstract void OnChanged(float newValue);
}
