using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawns : DespawnByDistance
{
    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
