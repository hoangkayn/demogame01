using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : BaseMonoBehaviour
{
    [SerializeField] private SpawnerCtrl spawnerCtrl;
    public SpawnerCtrl SpawnerCtrl { get => spawnerCtrl; }
    [SerializeField] protected float randomLimit = 9f;
    [SerializeField] protected float randomTimer;
    [SerializeField] protected float randomDelay = 2f;


    // Start is called before the first frame update
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSpawnerCtrl();
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (spawnerCtrl != null) return;
        spawnerCtrl = GetComponent<SpawnerCtrl>();

    }
    protected virtual void FixedUpdate()
    {
        JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (RandomReachLimit()) return;
        this.randomTimer += Time.fixedDeltaTime;
        if (randomTimer < randomDelay) return;
        randomTimer = 0;
        Vector3 pos = spawnerCtrl.SpawnPoints.GetRandom().position;
        Quaternion rot = transform.rotation;
        Transform prefab = spawnerCtrl.Spawner.RandomPrefab();

        Transform obj = spawnerCtrl.Spawner.Spawn(prefab, pos, rot);
    
        obj.gameObject.SetActive(true);

      

    }
    protected virtual bool RandomReachLimit()
    {
        int currentJunkCount = this.spawnerCtrl.Spawner.SpawnedCount;
        return currentJunkCount >= this.randomLimit;
    }
}

