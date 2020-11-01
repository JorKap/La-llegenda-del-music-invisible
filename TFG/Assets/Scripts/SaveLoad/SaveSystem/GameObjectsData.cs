using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectsData
{
    public bool[] state;
   // public GameObject[] gameObjects;
    public GameObjectsData(UnlockedGameObjects unlockedGameObjects)
    {
        ////gameObjects = new GameObject[unlockedGameObjects.gameObjectsUnlock.Length];
        //state = new bool[unlockedGameObjects.gameObjectsUnlock.Length];
        ////gameObjects = unlockedGameObjects.gameObjectsUnlock;
        //for (int i = 0; i < unlockedGameObjects.gameObjectsUnlock.Length; i++)
        //{
        //    state[i] = unlockedGameObjects.gameObjectsUnlock[i].GetComponent<GameObjectState>().enableGobj;
        //}
        state = unlockedGameObjects.state;
    }
}
