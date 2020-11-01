using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractableBeats : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.enabled = false;
    }
     public virtual void Interact()
    {
        Debug.Log("Interactable " + this);
        Debug.Log("Interacting with " + name);
    }
   
}
