using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePlace : MonoBehaviour
{
    //Posició on es posarà el player
    public Transform interactiveLocation;
    public InteractablePlace backPlace;
    [HideInInspector]
    public InteractablePlace backPlaceVar;

    InteractablePlace currentPlace;
    //Llista dels nodes accessibles des de la posició actual del player
    public List<InteractablePlace> reachablePlaces = new List<InteractablePlace>();

    //Classe que monitoritza els desplaçaments del player
    [HideInInspector]
    public PlayerManager playerManager;

    [HideInInspector]
    public Collider col;

    Interactable interactable;

    private void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
        playerManager = FindObjectOfType<PlayerManager>();
        backPlaceVar = backPlace;

    }

    private void Start()
    {
        interactable = GetComponent<Interactable>();

    }
    public void ReachablePlaces()
    {
        //Leave existing current node
        if (currentPlace != null)
        {
            currentPlace.Leave();
            
        }


        //set currentNode
        currentPlace = this;

        //turn off own collider
        //if (col != null)
        //{
        //    col.enabled = false;

        //}
        if (!interactable)
        {
            col.enabled = false;
        }
        if(this.interactable != null)
        {
            this.interactable.enabled = true;
            if(this.interactable.enabled && interactable.tag == "OnTriggerInteractable")
            {
                this.interactable.Interact();
                Debug.Log("OnTriggerInteractable");
            }
        }
        if (col.tag == "Interruptor")
            col.enabled = false;
        //turn on all reachable colliders

        SetReachablePlaces(true);


    }

    public void Leave()
    {
        SetReachablePlaces(false);
        

    }

    public void SetReachablePlaces(bool set)
    {
        //turn off all reachable colliders
        foreach (InteractablePlace place in reachablePlaces)
        {
            if (place.col != null)
            {

                place.col.enabled = set;

            }

            if (place.interactable != null)
                place.interactable.enabled = false;

        }
    }
}
