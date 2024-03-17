using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BaseMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance { get => instance; }
    public Camera mainCarema;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCamera();

    }
    protected virtual void LoadCamera() {
        if (mainCarema != null) return;
        mainCarema = Transform.FindObjectOfType<Camera>();

    }

}
