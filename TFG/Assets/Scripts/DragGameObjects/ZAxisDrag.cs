using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZAxisDrag : MonoBehaviour
{
    float rotSpeed = 20;
   
    float rotX;
    float rotY;
    float rotZ;
  
    Quaternion rotaY;
    Quaternion rotaX;
    Quaternion rotaZ;


    private float deltaX = 0f;
    private float deltaY = 0f;
    private Touch initTouch = new Touch();
    int dir = 1;
    public PlayerRotation playerRotation;
    public GameObject targetObject;
    public List<GameObject> EnableNewInteractablePlaces = new List<GameObject>();
    public GameObject panyEntrada;
    public bool keyOnPlace;
    Animator animator;
    private void Start()
    {
        //playerRotation = FindObjectOfType<PlayerRotation>();
        
        transform.localRotation = Quaternion.identity;
        animator = targetObject.GetComponent<Animator>();
    }

    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1.1f);
        //animator.SetBool("Open", false);
        for (int i = 0; i < EnableNewInteractablePlaces.Count; i++)
        {
            EnableNewInteractablePlaces[i].SetActive(true);
        }
        EnableNewInteractablePlaces[0].GetComponent<Collider>().enabled = true;
        panyEntrada.GetComponent<Collider>().enabled = false;
    }

    private void OnMouseDown()
    {
        playerRotation.enabled = false;
    }
    private void OnMouseUp()
    {
        playerRotation.enabled = true;
        rotZ = transform.localRotation.z;


    }

   
    private void OnMouseDrag()
    {
        if (keyOnPlace)
        {

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    initTouch = touch;


                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    deltaX = touch.deltaPosition.x;
                    deltaY = touch.deltaPosition.y;
                   // rotZ += deltaX * Time.deltaTime * rotSpeed * dir;
                    rotZ -= deltaY * Time.deltaTime * rotSpeed * dir;

                    rotZ = Mathf.Clamp(rotZ, 0, 90);
                
                    rotaZ = Quaternion.AngleAxis(rotZ, Vector3.forward);

                    if (rotZ > 85)
                    {
                        animator.enabled = true;
                        animator.SetBool("Open", true);
                    
                        StartCoroutine(StopAnimation());
                    }

                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    initTouch = new Touch();

                }

            }
                transform.localRotation = Quaternion.Slerp(transform.localRotation, rotaZ, Time.deltaTime * 2f);
        }
    }
   
}
