using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddReachablePlaceReaction : Reactions
{
    public InteractablePlace place;

    InteractablePlace currentPlace;

    private void Start()
    {
        currentPlace = transform.parent.parent.GetComponent<InteractablePlace>();
    }
    protected override void ImmediateReaction()
    {
        currentPlace.reachablePlaces.Add(place);
        currentPlace.SetReachablePlaces(true);
    }
}
