using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn: BaseMonoBehaviour
{
    protected void FixedUpdate()
    {
       
        Despawning();
    }

    protected abstract bool CanDespawn();
    public virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        DespawnObject();
    }
   
    protected virtual void OnEnable()
    {
        //to do
    }
   
}
