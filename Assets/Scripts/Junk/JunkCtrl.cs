using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : ShootableObjectCtrl
{
    protected override string GetObjectTypeToString()
    {
        return ObjectType.Junk.ToString();
    }
}

