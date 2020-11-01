using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleReaction : Reactions
{
    public Camera puzzleCamera;
    public bool on;

    protected override void ImmediateReaction()
    {
        puzzleCamera.enabled = on;
    }
}
