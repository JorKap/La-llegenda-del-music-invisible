using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledReaction : Reactions
{
    public GameObject gObj;
    public bool state;

  
    protected override void ImmediateReaction()
    {
        gObj.SetActive( state);
    }
}
