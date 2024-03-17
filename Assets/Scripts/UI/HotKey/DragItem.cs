using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class DragItem : BaseMonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Image image;
    [SerializeField] protected Transform realParent;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.GetComponent<Image>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        realParent = transform.parent;
        transform.parent = UIHotKeyCtrl.Instance.transform;
        this.image.raycastTarget = false;
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 mousePos = InputManager.Instance.MousePosition;
        mousePos.z = 0;
        transform.position = mousePos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.parent = realParent;
        this.image.raycastTarget = true;
    }

    public void SetRealParent(Transform transform)
    {
        this.realParent = transform;
        
    }
}
