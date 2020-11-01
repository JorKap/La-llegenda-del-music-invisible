using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectState : MonoBehaviour
{
    public bool enableGobj;
   

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.GetChild(0).gameObject.SetActive(enableGobj);
    }
}
