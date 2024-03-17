using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAppearing : BaseMonoBehaviour
{
    [Header("Obj Appearing")]
    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IObjectAppearObserver> observers = new List<IObjectAppearObserver>();

    public bool Appeared => appeared;

    protected override void Start()
    {
        base.Start();
        this.OnAppearStart();
    }

    protected virtual void OnDisable()
    {
       // base.OnDisable();
        this.appeared = false;
        this.OnAppearStart();
    }

    protected virtual void FixedUpdate()
    {
        this.Appearing();
    }

    protected abstract void Appearing();

    public virtual void Appear()
    {
        this.appeared = true;
        this.OnAppearFinish();
    }

    public virtual void ObserverAdd(IObjectAppearObserver observer)
    {
        this.observers.Add(observer);
    }

    protected virtual void OnAppearStart()
    {
        foreach (IObjectAppearObserver observer in this.observers)
        {
            observer.OnAppearStart();
        }
    }

    protected virtual void OnAppearFinish()
    {
        foreach (IObjectAppearObserver observer in this.observers)
        {
            observer.OnAppearFinish();
        }
    }
}