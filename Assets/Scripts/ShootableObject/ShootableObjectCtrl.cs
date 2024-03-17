using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn { get => despawn; }

    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO { get => shootableObjectSO; }

    [SerializeField] protected ObjectShooting objectShooting;
    public ObjectShooting ObjectShooting { get => objectShooting; }

    [SerializeField] protected ObjectMovement objectMovement;
    public ObjectMovement ObjectMovement => objectMovement;

    [SerializeField] protected ObjectLookAtTarget objectLookAtTarget;
    public ObjectLookAtTarget ObjectLookAtTarget => objectLookAtTarget;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadModel();
        LoadDespawn();
        this.LoadShootableObject();
        this.LoadObjectShooting();
        this.LoadObjectMovement();
        this.LoadObjectLookAtTarget();
        this.LoadSpawner();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
    }
    protected virtual void LoadObjectShooting()
    {
        if (this.objectShooting != null) return;
        this.objectShooting = transform.GetComponentInChildren<ObjectShooting>();
    }

    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
    }
    protected virtual void LoadObjectMovement()
    {
        if (this.ObjectMovement != null) return;
        this.objectMovement = transform.GetComponentInChildren<ObjectMovement>();
    }
    protected virtual void LoadObjectLookAtTarget()
    {
        if (this.objectLookAtTarget != null) return;
        this.objectLookAtTarget = transform.GetComponentInChildren<ObjectLookAtTarget>(); ;
    }
    protected virtual void LoadShootableObject()
    {
        if (shootableObjectSO != null) return;
        string resPath = "ShootableObject/" + this.GetObjectTypeToString() + "/" + transform.name;
        shootableObjectSO = Resources.Load<ShootableObjectSO>(resPath);
    }

    protected abstract string GetObjectTypeToString();


    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.Find("Despawn").GetComponent<Despawn>();
    }
    protected virtual void LoadDamageReceiver() {
        if (damageReceiver != null) return;
        damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
    }

}
