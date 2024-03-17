using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Spawner : BaseMonoBehaviour
{
   
    [SerializeField] protected List<Transform> prefabs;
    protected List<Transform> poolObjs = new List<Transform>();
    [SerializeField] protected Transform holder;
    [SerializeField] protected int spawnedCount = 0;
    public int SpawnedCount { get => spawnedCount; }

    protected override void LoadComponent()
    {
        LoadPrefabs();
        LoadHolder();
       
    }
   


    protected virtual void LoadHolder()
    {
        if (holder != null) return;
        holder = transform.Find("Holder");
        Debug.Log(transform.name + ": LoadHolder",gameObject);
    }

    protected virtual void LoadPrefabs()
    {
        if (prefabs.Count > 0) return;
        GameObject prefabObj = transform.Find("Prefabs").gameObject;
        foreach(Transform child in prefabObj.transform)
        {
            prefabs.Add(child);
        }
        HidePrefabs();
    }
    protected virtual void HidePrefabs()
    {
        foreach( Transform child in prefabs)
        {
            child.gameObject.SetActive(false);
        }
    }

   
    public virtual Transform Spawn(string namePrefab,Vector3 position, Quaternion rotation)
    {
        Transform prefab = GetPrefabByName(namePrefab);
        if(prefab == null)
        {
            Debug.LogError("prefab is null");
        }
        return Spawn(prefab, position, rotation);
       
    }
    public virtual Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(position, rotation);
        newPrefab.SetParent(this.holder);
        spawnedCount++;
        return newPrefab;
    }
    protected virtual Transform GetPrefabByName(string namePrefab)
    {
        foreach(Transform item in prefabs)
        {
            if(item.name == namePrefab)
            {
                return item;
            }
          
        }
        return null;
    }
    protected virtual Transform GetObjectFromPool(Transform prefab)
    {
        
        foreach(Transform item in poolObjs)
        {
            if (item == null) continue;
            if(item.name == prefab.name)
            {
                poolObjs.Remove(item);
                return item;
            }
        }
        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }
    public virtual void Despawn(Transform obj)
    {
        if (this.poolObjs.Contains(obj)) return;
        poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        spawnedCount--;
    }
    public virtual Transform RandomPrefab()
    {
        int index = Random.Range(0,prefabs.Count);      
        return prefabs[index];
    }
    public virtual void Hold(Transform obj)
    {
        obj.parent = this.holder;
    }

   
}
