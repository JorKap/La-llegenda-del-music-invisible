using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class ConditionsManager : MonoBehaviour
{
    public string description;
    public RequiredCondition[] requirements = new RequiredCondition[0];
    [Space]
    public ReactionsManager postReactions;

   

    public bool ConditionsCheckIn()
    {
        for (int i = 0; i < requirements.Length; i++)
        {
            if (!ConditionsDatabase.ConditionCheckIn(requirements[i]))
                return false;
        }

        if (postReactions)
        {
            postReactions.React();
        }

        return true;
    }
}




