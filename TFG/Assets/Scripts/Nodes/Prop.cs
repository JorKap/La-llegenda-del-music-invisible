using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prop : Node
{
    public Location loc;
    Interactable interactiu;
    ClampImage clampImage;
    GameObject pl;
    PlayerRotation playerRotation;

  

    private void Start()
    {
        interactiu = GetComponent<Interactable>();
        //clampImage = GetComponent<ClampImage>();
        playerRotation = FindObjectOfType<PlayerRotation>();
        playerRotation.enabled = true;
    }
   

    public override void ReachableNodes()
    {
        //if(interactiu != null && interactiu.enabled)
        //{
        //    interactiu.Interact();
        //    return;
        //}
        base.ReachableNodes();

       
        if(interactiu != null)
        {
            col.enabled = true;
            interactiu.enabled = true;

        }
       

        //if (clampImage != null)
        //    clampImage.placeHolder.gameObject.SetActive(true);

      

    }

    public override void Leave()
    {
       
        base.Leave();
        
        if(interactiu != null)
        {
            interactiu.enabled = false;
            col.enabled = false;
          //  GameManager.instance.messagesCanvas.GetComponentInChildren<Text>().text = "";

        }
       

        if (clampImage != null)
            clampImage.placeHolder.gameObject.SetActive(false);

        
    }
}
