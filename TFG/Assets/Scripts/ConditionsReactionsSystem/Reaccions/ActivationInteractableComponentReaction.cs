using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationInteractableComponentReaction : Reactions
{
    public Interactable interactable;
    public bool enable;
    protected override void ImmediateReaction()
    {
        interactable.enabled = enable;
    }
}
