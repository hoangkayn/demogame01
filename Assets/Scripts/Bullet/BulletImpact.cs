using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class BulletImpact : BulletAbstract
{
    [Header("BulletImpact")]

    [SerializeField] protected Rigidbody _rigidbody;
 

    [SerializeField] protected SphereCollider sphereCollider;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigibody();
        this.LoadSphereCollider();
    }
    protected virtual void LoadRigibody()
    {
        if (_rigidbody != null) return;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.radius = 0.06f;
        sphereCollider.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other) 
    {
        
        if (other.transform.parent == bulletCtrl.Shooter) return;
        bulletCtrl.BulletDamageSender.Send(other.transform);
       

    }
    
}
