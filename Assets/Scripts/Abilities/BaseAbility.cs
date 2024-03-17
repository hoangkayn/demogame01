using System.Collections;

using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAbility : BaseMonoBehaviour
{
    [Header("Base Ability")]
    [SerializeField] protected Abilities abilities;
    public Abilities Abilities { get => abilities; }
    [SerializeField] protected float timer = 2f;
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected bool isReady = false;


    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAbilities();

    }
    protected virtual void LoadAbilities()
    {
        if (this.abilities != null) return;
        this.abilities = transform.parent.GetComponent<Abilities>();
    }
    protected virtual void FixedUpdate()
    {
        this.Timing();
    }
    protected virtual void Update()
    {
        //to do
    }
    protected virtual void Timing()
    {
        if (this.isReady) return;
        this.timer += Time.fixedDeltaTime;
        if (this.timer < this.delay) return;
        this.isReady = true;
    }

    public virtual void Active()
    {
        this.isReady = false;
        this.timer = 0;
    }
}
