using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public int space = 4;
    public bool isPaused;
    //public InventoryUI inventoryUI;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;


    }

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    public List<Item> items = new List<Item>();
   
    public bool Add(Item item)
    {
        if(items.Count>= space)
        {
            Debug.Log("Not enough room in inventory");
            return false;
        }
        items.Add(item);
        onItemChangeCallback.Invoke();
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangeCallback.Invoke();

    }

    //private void OnEnable()
    //{
    //    InventoryData inventoryData = SaveSystemJSON.LoadInventoryData();
    //    if(inventoryData.items.Count > 0)
    //        items = inventoryData.items;

    //}

    //private void OnDisable()
    //{
    //    //Debug.Log("OnDisable");
    //    SaveSystemJSON.SaveInventoryData(this);
    //}

    private void OnApplicationQuit()
    {
       // Debug.Log("OnApplicationQuit");
        SaveSystemJSON.SaveInventoryData(this);
    }

   
    private void OnApplicationPause(bool pause)
    {
        //Debug.Log("OnApplicationPause");
        SaveSystemJSON.SaveInventoryData(this);
    }
}
