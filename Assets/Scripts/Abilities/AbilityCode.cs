

using System;
using UnityEngine;

public enum AbilityCode
{
    NoAbility = 0,
    Missle = 1,
    Laze = 2,

}
public class AbilityCodeParser
{
    public static AbilityCode FromString(string itemName)
    {
        try
        {
            return (AbilityCode)System.Enum.Parse(typeof(AbilityCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return AbilityCode.NoAbility;
        }
    }
}