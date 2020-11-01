using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotObserver : MonoBehaviour
{
    Inventory inventory;
    Item itemSlot;
    PlayerRotation playerRotation;
    PlayerManager playerManager;
    private void Awake()
    {
        playerRotation = FindObjectOfType<PlayerRotation>();
        playerManager = FindObjectOfType<PlayerManager>();
    }
    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void Interact()
    {
        playerManager.enabled = false;
        playerRotation.enabled = false;
        itemSlot =  GetComponent<InventorySlot>().item;
        GameObject item = Instantiate(itemSlot.gameObject);
        item.transform.SetParent(GameManager.instance.obsCamera.rig);
        item.transform.localPosition = Vector3.zero;
        //item.transform.GetChild(1).transform.localPosition = Vector3.zero;
        GameManager.instance.obsCamera.model = item;
        GameManager.instance.obsCamera.gameObject.SetActive(true);
        GameManager.instance.observerCameraButton.SetActive(true);
        //GameManager.instance.currentNode.SetReachableNodes(false);
        //GameManager.instance.currentNode.col.enabled = false;
    }

   
}
