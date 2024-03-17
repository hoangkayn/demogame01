using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }

 
   // public string meteoriteOne = "Meteorite";
    protected override void Awake()
    {
        base.Awake();
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public override Transform Spawn(Transform prefab, Vector3 position, Quaternion rotation)
    {
        Transform newEnemy = base.Spawn(prefab,position,rotation);
        this.AddHPBarToObj(newEnemy);
        return newEnemy;
    }
  
    protected virtual void AddHPBarToObj(Transform newEnemy)
    {
        ShootableObjectCtrl enemyCtrl = newEnemy.GetComponent<ShootableObjectCtrl>();
        Transform newHPBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBar,newEnemy.position,Quaternion.identity);
        HPBar hPBar = newHPBar.GetComponent<HPBar>();
        hPBar.SetObjCtrl(enemyCtrl);
        hPBar.SetFollowTarget(newEnemy);
        newHPBar.gameObject.SetActive(true);
    }
}
