using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronItemDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        DropItemSpawner.Instance.Despawn(transform.parent);
    }
}
