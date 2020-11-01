using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detail : Node
{
    public Prop prop;
    PlayerRotation playerRotation;

    private void Start()
    {
        playerRotation = FindObjectOfType<PlayerRotation>();
        playerRotation.enabled = false;
    }
}
