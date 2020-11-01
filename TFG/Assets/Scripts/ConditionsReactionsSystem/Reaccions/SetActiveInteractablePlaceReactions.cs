using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveInteractablePlaceReactions : Reactions
{
    public List<GameObject> activeInteractablePlace = new List<GameObject>();
    public bool state;
   
    protected override void ImmediateReaction()
    {
        for (int i = 0; i < activeInteractablePlace.Count; i++)
        {
            activeInteractablePlace[i].SetActive(state);
        }
    }
}
