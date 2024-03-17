using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]
public class ShootableObjectSO : ScriptableObject
{
    public string shootableObject = "Shootable Object";
    public ObjectType objectType = ObjectType.None;
    public int maxHp = 2;
    public List<ItemDropRate> dropList;
}
