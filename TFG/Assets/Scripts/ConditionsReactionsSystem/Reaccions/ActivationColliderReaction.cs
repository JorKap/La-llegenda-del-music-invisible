using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationColliderReaction : Reactions
{
    public GameObject gObj;
    Collider colliders;
    public bool enable;

    private void Start()
    {
        colliders = gObj.GetComponent<Collider>();
    }

    protected override void ImmediateReaction()
    {
        colliders.enabled = enable;
    }
}
