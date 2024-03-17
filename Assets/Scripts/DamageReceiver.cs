using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : BaseMonoBehaviour
{
    [SerializeField] protected int currentHp;
    [SerializeField] protected int maxHp = 2;
    public int MaxHP => maxHp;
    public int CurrentHP => currentHp;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected bool isDead = false;
    protected override void LoadComponent()
    {


        base.LoadComponent();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0.55f;
    }
    protected virtual void OnEnable()
    {
        this.Reborn();
        isDead = false;
    }
    protected virtual void Reborn()
    {
        currentHp = maxHp;
   
    }
    public virtual void Add(int add)
    {
        if (isDead) return;
        this.currentHp += add;
        if (this.currentHp > maxHp) currentHp = maxHp;
    }
    public virtual void Deduct(int deduct)
    {
        if (isDead) return;
        this.currentHp -= deduct;
        if (currentHp < 0) currentHp = 0;
        this.CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return currentHp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        OnDead();
    }
    protected abstract void OnDead();
   // protected abstract void OnDeadDrop();
    
}
