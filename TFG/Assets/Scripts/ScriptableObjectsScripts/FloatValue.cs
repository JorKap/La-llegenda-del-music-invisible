using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatValue : MonoBehaviour
{
    [CreateAssetMenu]
    [System.Serializable]
    public class BoolValue : ScriptableObject
    {
        public float initialValue;
        public float RuntimeValue;
    }

}
