using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorReaction : Reactions
{
    public GameObject obj;
    public Color active;
    // public Color inactive;

    MeshRenderer mesh;
    private void Awake()
    {
        mesh = obj.GetComponent<MeshRenderer>();

    }

    protected override void ImmediateReaction()
    {

        mesh.material.color = active;
    }
}
