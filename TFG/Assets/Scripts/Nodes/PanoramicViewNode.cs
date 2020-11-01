using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanoramicViewNode : Node
{
    PlayerRotation touchPOV;

    // Start is called before the first frame update
    void Start()
    {
        touchPOV = FindObjectOfType<PlayerRotation>();

    }

   
    //public override void Arrive()
    //{
    //    base.Arrive();
    //    touchPOV.clampRotation = new ClampRotation(minX, maxX, minY, maxY);
    //    touchPOV.rotXClampOn = true;
    //}
    //public override void Leave()
    //{
    //    touchPOV.rotXClampOn = false;

    //    base.Leave();
    //}
}
