using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAbility : BaseAbility
{
    public virtual void Press()
    {
        Debug.Log("Press: " + transform.parent.parent.name);
    }
}
