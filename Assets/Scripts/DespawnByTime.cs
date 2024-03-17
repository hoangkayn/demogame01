using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timer;
    [SerializeField] protected float delay = 2f;
    protected override bool CanDespawn()
    {
        this.timer += Time.fixedDeltaTime;
        if (timer > delay) return true;

        return false;

    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();

    }
    protected virtual void ResetTimer()
    {
        timer = 0;
    }



}
