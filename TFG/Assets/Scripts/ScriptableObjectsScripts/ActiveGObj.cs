using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new activation", menuName = "ActiveGObj")]
public class ActiveGObj : ScriptableObject
{
    public GameObject gameObject;
    public bool active;

}
