using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivationTextComponentReaction : Reactions
{
    public TextReaction text;
    public bool enable;
    protected override void ImmediateReaction()
    {
        text.textEnable = enable;
    }
}
