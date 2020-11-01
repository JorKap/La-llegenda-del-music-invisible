using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockedGameObjects : MonoBehaviour
{
    public static UnlockedGameObjects instance;
   // public GameObjectState[] gameObjectsState;
    public GameObject[] gameObjectsUnlock;
    public delegate void OnStateChange();
    public OnStateChange onStateChangeChangeCallback;
    public bool[] state;
    GameObjectsData gameObjectsData;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of inventory found!");
            return;
        }
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
       state = new bool[gameObjectsUnlock.Length];
        for (int i = 0; i < gameObjectsData.state.Length; i++)
        {
            gameObjectsUnlock[i].GetComponent<GameObjectState>().enableGobj = gameObjectsData.state[i];
        }
    }

    // Update is called once per frame
    void Update()
    {

       
    }
    public void StateUpdate()
    {
        for (int i = 0; i < gameObjectsUnlock.Length; i++)
        {
            state[i] = gameObjectsUnlock[i].GetComponent<GameObjectState>().enableGobj;
        }
    }
    private void OnEnable()
    {
         gameObjectsData = SaveSystemJSON.LoadGameObjectsData();

        
    }

    private void OnDisable()
    {
        
        SaveSystemJSON.SaveGameObjectsData(this);
       
    }
    public void GameObjectsState(bool _state, string _name)
    {
        for (int i = 0; i < gameObjectsUnlock.Length; i++)
        {
          // state[i] = gameObjectsUnlock[i].GetComponent<GameObjectState>().enableGobj;
          if(gameObjectsUnlock[i].name == _name)
            {
                gameObjectsUnlock[i].GetComponent<GameObjectState>().enableGobj = _state;
            }
                Debug.Log("State " + gameObjectsUnlock[i].GetComponent<GameObjectState>().enableGobj);

        }
        //for (int i = 0; i < gameObjectsState.Length; i++)
        //{
        //  // state = gameObjectsState[i].enableGobj;
        //    //gameObjectsUnlock[i].SetActive();
        //}
    }
}
