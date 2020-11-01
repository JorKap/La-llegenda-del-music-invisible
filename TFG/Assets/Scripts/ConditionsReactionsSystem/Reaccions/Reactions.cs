using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public abstract class Reactions: MonoBehaviour
{
    public void React(MonoBehaviour monoBehaviour)
    {
        ImmediateReaction();
    }


    // This is the core of the Reaction and must be overridden to make things happpen.
    protected abstract void ImmediateReaction();
}
