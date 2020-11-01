using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

  
    public Camera cam;
    public DoubleClick doubleClick;

   
    private GameObject gObj = null;
    private Plane objPlane;
    private Vector3 mouseOffset;


    
    PlayerRotation playerRotation;
    Transform targetPlace;
    Node node;
    Node backNode = null;
    InteractablePlace place;
    public InteractablePlace backInteractablePlace;
    Interactable interactable;
    Transform newTransform;
    string targetName;

    float previousTouchDistance;
    float deltaDistance;

    private float deltaX = 0f;
    private float deltaY = 0f;
    private Touch initTouch = new Touch();
    float posX;
    Vector3 position;
    bool on;
    EnableCollider enableCollider;
    bool moveEnded;
    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }

        moveEnded = true;
       
    }

    private void Start()
    {

       // distanceCamFromParent = -1.2f;
        playerRotation = GetComponent<PlayerRotation>();
        //node = GameManager.instance.StartingNode;
        //SetNewTransform(node);
       // node = transform.parent.transform.parent.GetComponent<Node>();
        place = transform.parent.parent.GetComponent<InteractablePlace>();
        SetNewTransform(place);

    }

    // Update is called once per frame
    void Update()
    {
       

        if (newTransform)
            Move();

        //Detectem nodes on es desplaça el player i activem el desplaçament amb un doble "tap"
        if (doubleClick.doubleClickDone)
        {
           
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (moveEnded)
                {
                    place = hit.collider.GetComponent<InteractablePlace>();
                    enableCollider = hit.collider.GetComponent<EnableCollider>();

                    if (place != null)
                    {
                        Debug.Log("place collider: " + hit.collider.name);

                        SetNewTransform(place);
                        if(place.name == "InterruptorParetExterior")
                        {
                            GameManager.instance.interruptorParetExterior.GetComponent<Collider>().enabled = true;
                        }

                    }


                    if (enableCollider != null)
                    {
                        Debug.Log("enable collider: " + hit.collider.name);
                        enableCollider.EnableCol();
                    }
                }

                
            }
            doubleClick.doubleClickDone = false;
        }

        //Usem dos dits per retornar a una posició 
       

        if (Input.touchCount == 2)
        {
            // transform.parent.localRotation = Quaternion.identity;
            if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(1).phase == TouchPhase.Began)
            {
                playerRotation.enabled = false;

                previousTouchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
                backInteractablePlace = place.backPlaceVar;


            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved)
            {
                float distance;
                Vector2 touch1 = Input.GetTouch(0).position;
                Vector2 touch2 = Input.GetTouch(1).position;
                distance = Vector2.Distance(touch1, touch2);
                deltaDistance = previousTouchDistance - distance;

                if (deltaDistance > 40f)
                {
                    
                    GameManager.instance.interruptorParetExterior.GetComponent<Collider>().enabled = false;
                    SetNewTransform(backInteractablePlace);
                        
                }

            }
            if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(1).phase == TouchPhase.Ended)
            {
                playerRotation.enabled = true;

                if(enableCollider!= null)
                enableCollider.DisableCol();

               
            }
        }
        

    }

    void SetNewTransform(InteractablePlace _place)
    {
        //Desvinculem del pare
        transform.parent = null;
        //Assignem el lloc de destí
        newTransform = _place.interactiveLocation;
        //Orientem correctament el lloc de destí
        newTransform.localRotation = Quaternion.identity;
        //Assignem el lloc de destí com a pare
        transform.parent = newTransform;
        targetName = newTransform.tag;
        //rotació
        playerRotation.SetRotationValues(0, 0, Quaternion.identity);
        playerRotation.GetTargetName(targetName);
        //Activem els nodes
        _place.ReachablePlaces();
        place = _place;
    }

    void Move()
    {
        playerRotation.enabled = false;
        moveEnded = false;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, Time.deltaTime * 4f);
       // transform.parent.localRotation = Quaternion.identity;
       // playerRotation.enabled = false;

        if (targetName == "Panoramic")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 4f);

            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;
            }
        }
        if (targetName == "LookAt")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, -2), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, -2)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, -2);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;

            }

        }
        if (targetName == "Detail")
        {

            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, -0.5f), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, -0.5f)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, -0.5f);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                playerRotation.enabled = true;
                moveEnded = true;

            }

        }
        if (targetName == "NoRotation")
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 4f);
            if (Vector3.Distance(transform.localPosition, new Vector3(0, 0, 0)) < 0.03)
            {
                transform.localPosition = new Vector3(0, 0, 0);
                transform.localRotation = Quaternion.identity;
                newTransform = null;
                moveEnded = true;

                // playerRotation.enabled = true;
            }
        }

       
    }

   

    private void OnApplicationQuit()
    {
        SaveSystemJSON.SavePlayerData(this);
    }



    private void OnApplicationPause(bool pause)
    {
        SaveSystemJSON.SavePlayerData(this);
    }

}
