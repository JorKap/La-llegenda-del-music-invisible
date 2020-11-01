using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectStateReaction : Reactions
{
    public GameObject gameObj;       // The gameobject to be turned on or off.
    public bool activeState;            // The state that the gameobject will be in after the Reaction.

    public float delay;             // All DelayedReactions need to have an time that they are delayed by.
    protected WaitForSeconds wait;
    private void Start()
    {
        wait = new WaitForSeconds(delay);
    }
    protected override void ImmediateReaction()
    {
       // gameObj.SetActive(activeState);
       StartCoroutine(TimeDelay());
    }

   

    protected IEnumerator TimeDelay()
    {
        yield  return  wait;
        gameObj.SetActive(activeState);

    }
}
