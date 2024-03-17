using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBtn : BaseMonoBehaviour
{
    [SerializeField] protected Button button;


    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadButton();
    }
    protected override void Start()
    {
        base.Start();
        this.OnClickEvent();
    }
    protected virtual void LoadButton() {
        if (this.button != null) return;
        this.button = GetComponent<Button>();
    }
    protected virtual void OnClickEvent()
    {
        this.button.onClick.AddListener(this.OnClick);
    }
    protected abstract void OnClick();
}
