using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySummonEnemy: AbilitySummon
{
    //[Header("Ability Summon Enemy")]
    [SerializeField] protected int minionLimit = 4;
    [SerializeField] protected List<Transform> minions = new List<Transform>();
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemySpawner();

    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.ClearnMinionsDead();
    }
    protected virtual void ClearnMinionsDead()
    {
        foreach(Transform minion in minions)
        {
            if(minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
    protected override void Summoning()
    {
        if (this.minions.Count >= this.minionLimit) return;
        base.Summoning();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.spawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.spawner = enemySpawner.GetComponent<EnemySpawner>();
    }
    protected override Transform Summon()
    {
        Transform minion = base.Summon();
        minion.parent = this.abilities.AbilityObjectCtrl.transform;
        this.minions.Add(minion);
        return minion;
    }
}
