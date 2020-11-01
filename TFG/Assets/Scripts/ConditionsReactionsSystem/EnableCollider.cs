using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCollider : MonoBehaviour
{
    public GameObject gObj;
    private Collider col;
    // Start is called before the first frame update
    void Start()
    {
        col = gObj.GetComponent<Collider>();
    }

    public void EnableCol()
    {
        Debug.Log("col " + col.name);
        if(col != null)
        {
            col.enabled = true;
        }
    }

    public void DisableCol()
    {
        if (col != null)
        {
            col.enabled = false;
        }
    }
}
