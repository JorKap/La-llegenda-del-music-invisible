using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationObserverComponentReaction : Reactions
{
    public GameObject component;     // The Condition to be changed.
    Observer observer;

    private void Awake()
    {
         observer = component.GetComponent<Observer>();
    }
    protected override void ImmediateReaction()
    {
        observer.enabled = true;
    }
}
