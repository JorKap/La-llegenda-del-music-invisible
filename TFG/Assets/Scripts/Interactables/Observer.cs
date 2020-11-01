using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : InteractableBeats
{
    public override void Interact()
    {
        GameObject item = Instantiate(gameObject);
        item.transform.SetParent(GameManager.instance.obsCamera.rig);
        item.transform.localPosition = Vector3.zero;
        item.transform.GetChild(1).transform.localPosition = Vector3.zero;
        GameManager.instance.obsCamera.model = item;
        GameManager.instance.obsCamera.gameObject.SetActive(true);
        GameManager.instance.currentNode.SetReachableNodes(false);
        GameManager.instance.currentNode.col.enabled = false;

    }
}
