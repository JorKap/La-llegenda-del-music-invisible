using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
   // [HideInInspector]
    public Node currentNode;
  //  public Node StartingNode;
    public IVCanvas iVCanvas;
    public ObsCamera obsCamera;
    public GameObject observerCameraButton;
    public ItemDragHandler currentItemDrag;
    public PlayerManager playerManager;
   // public GameObject messagesCanvas;
    public PlayerRotation playerRotation;
    public InteractablePlace currentPlace;

    public GameObject interruptorParetExterior;
    public GameObject EntradaCasa;


   // public InteractablePlace startingPlace;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        iVCanvas.gameObject.SetActive(false);
        obsCamera.gameObject.SetActive(false);
       
      //  messagesCanvas.SetActive(false);
      
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        
    }

}
