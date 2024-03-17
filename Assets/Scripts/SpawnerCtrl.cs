using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : BaseMonoBehaviour
{
    [SerializeField] private Spawner spawner;
    public Spawner Spawner { get => spawner; }

    [SerializeField] private SpawnPoints spawnPoints;
    public SpawnPoints SpawnPoints { get => spawnPoints; }
    // Start is called before the first frame update
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSpawner();
        LoadSpawnerPoints();
    }
    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = GetComponent<Spawner>();

    }
    protected virtual void LoadSpawnerPoints()
    {
        if (spawnPoints != null) return;
        spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();

    }
}
