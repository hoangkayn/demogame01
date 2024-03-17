using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoints : BaseMonoBehaviour
{
    [SerializeField] protected List<Transform> points;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPoints();
    }
    protected virtual void LoadPoints() {
        if (points.Count > 0) return;
        foreach(Transform child in transform)
        {
            points.Add(child);
        }
    }
    public virtual Transform GetRandom()
    {
        int ran = Random.Range(0, points.Count);
        return points[ran];
    }
}
