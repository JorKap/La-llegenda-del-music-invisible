using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Interactable : MonoBehaviour
{

    public ConditionsManager[] requirements = new ConditionsManager[0];
    [Space]
    public ReactionsManager defaultReactions;
    public float radius = 1f;
    public bool onTriggerBool;

    public void InteractableDone()
    {
        Debug.Log("InteractableDone");
    }
    private void Awake()
    {
        this.enabled = false;
    }
    private void Start()
    {
        
    }
    public void Interact()
    {
        
        for (int i = 0; i < requirements.Length; i++)
        {
            if (requirements[i].ConditionsCheckIn())
            {
               return;

            }
        }
        if(defaultReactions)
         defaultReactions.React();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void OnMouseDown()
    {
        if (this.enabled && !onTriggerBool)
        {
            Interact();
            Debug.Log("Interact");
        }
    }
}
