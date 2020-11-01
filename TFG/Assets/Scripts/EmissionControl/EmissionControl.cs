using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour
{
    public Material[] material;
    public bool onEmission;

    private void Awake()
    {
        for (int i = 0; i < material.Length; i++)
        {
            material[i].DisableKeyword("_EMISSION");
        }
       
    }
    

    // Update is called once per frame
    void Update()
    {
        if (onEmission)
        {
            for (int i = 0; i < material.Length; i++)
            {
                material[i].EnableKeyword("_EMISSION");

            }
        }
        else
        {
            for (int i = 0; i < material.Length; i++)
            {
                material[i].DisableKeyword("_EMISSION");

            }
        }
    }
}
