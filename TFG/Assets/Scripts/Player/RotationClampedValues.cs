using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RotationClampedValues 
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
   
    public RotationClampedValues(float _minX, float _maxX, float _minY, float _maxY)
    {
        minX = _minX;
        maxX = _maxX;
        minY = _minY;
        maxY = _maxY;

    }
   
       
}
