using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLookAtPlayer : ObjectLookAtTarget
{
    [SerializeField] protected Transform player;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayer();
    }
    protected override void FixedUpdate()
    {
        this.GetPlayerPos();
        base.FixedUpdate();
    }

    protected virtual void GetPlayerPos()
    {
        this.targetPosition = this.player.position;
    }
    protected virtual void LoadPlayer()
    {
        if (player != null) return;
        player = GameObject.Find("ship").transform;
    }
}
