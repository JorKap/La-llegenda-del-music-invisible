using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionReaction: Reactions 
{
    public Condition condition;     // The Condition to be changed.
    public bool satisfied;          // The satisfied state the Condition will be changed to.


    protected override void ImmediateReaction()
    {
        condition.satisfied = satisfied;
    }
   
}
