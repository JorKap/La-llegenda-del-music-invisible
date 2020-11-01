//Les classes que hereten de Node són components de GameObjects als quals es desplaçarà el player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour
{
    //Posició on es posarà el player
    public Transform interactionLocation;

    //Llista dels nodes accessibles des de la posició actual del player
    public List<Node> reachableNodes = new List<Node>();

    //Classe que monitoritza els desplaçaments del player
    [HideInInspector]
    public PlayerManager playerManager;

    [HideInInspector]
    public Collider col;
    [SerializeField]


    private void Awake()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
        playerManager = FindObjectOfType<PlayerManager>();
    }
   

    public virtual void ReachableNodes()
    {
        //Leave existing current node
        if (GameManager.instance.currentNode != null)
             GameManager.instance.currentNode.Leave();

        //set currentNode
        GameManager.instance.currentNode = this;
        //Debug.Log("this name: " + this.name);
        //Interactable interactable = this.transform.Find("InteractablePrefab").GetComponent<Interactable>();
        //if (interactable != null)
        //    interactable.InteractableDone();
        //turn off own collider
        if (col != null)
        {
            col.enabled = false;

        }
        //turn on all reachable colliders
       
            SetReachableNodes(true);

        
    }

    public virtual void Leave()
    {
        SetReachableNodes(false);
    }

    public void SetReachableNodes(bool set)
    {
        //turn off all reachable colliders
        foreach (Node node in reachableNodes)
        {
            if (node.col != null)
            {
                
                    node.col.enabled = set;

            }

        }
    }
}
