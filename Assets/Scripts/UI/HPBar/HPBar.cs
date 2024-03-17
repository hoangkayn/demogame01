using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : BaseMonoBehaviour
{
    [Header("HP Bar")]
    [SerializeField] ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;
    protected virtual void FixedUpdate() {
        this.CheckIsDead();
        this.HPShowing();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
       
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
       
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent.parent.GetComponent<Spawner>();
        
    }
   protected virtual void LoadSliderHP()
    {
        if (this.sliderHP != null) return;
        this.sliderHP = transform.GetComponentInChildren<SliderHP>();
    }
    protected virtual void LoadFollowTarget()
    {
        if (this.followTarget != null) return;
        this.followTarget = transform.GetComponent<FollowTarget>();
    }
    protected virtual void CheckIsDead()
    {
        bool dead = shootableObjectCtrl.DamageReceiver.IsDead();
        if (dead) HPBarSpawner.Instance.Despawn(transform);
    }

    protected virtual void HPShowing() {
        
        float currentHP = shootableObjectCtrl.DamageReceiver.CurrentHP;
        float maxHP = shootableObjectCtrl.DamageReceiver.MaxHP;
        sliderHP.SetCurrentHP(currentHP);
        sliderHP.SetMaxHP(maxHP);
    }

    public virtual void SetObjCtrl(ShootableObjectCtrl shootableObjectCtrl)
    {
        this.shootableObjectCtrl = shootableObjectCtrl;
    }
    public virtual void SetFollowTarget(Transform target)
    {
        this.followTarget.SetTarget(target);
    }

}
