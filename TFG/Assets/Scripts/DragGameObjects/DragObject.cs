using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public float lerpSpeed = 1.5f;
    public float posXSpeed = 0.1f;
    public Interactable interactable;
    private float deltaX = 0f;
    private float deltaY = 0f;
    private Touch initTouch = new Touch();
    float posX;
    Vector3 position;
    PlayerRotation playerRotation;

    private void Start()
    {
        playerRotation = FindObjectOfType<PlayerRotation>();
        position = transform.localPosition;
        posX = transform.localPosition.x;
    }
    

   
    private void OnMouseUp()
    {
        playerRotation.enabled = true;

        position = transform.localPosition;
        posX = transform.localPosition.x;

    }

    private void OnMouseDrag()
    {
        playerRotation.enabled = false;
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {

            initTouch = touch;

        }
        else if (touch.phase == TouchPhase.Moved)
        {
            deltaX = touch.deltaPosition.x;
            deltaY = touch.deltaPosition.y;

            posX += deltaX * Time.deltaTime * 0.1f;
            posX = Mathf.Clamp(posX, -0.45f, 0.45f);

            position = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
            // transform.localPosition = new Vector3(posX, transform.localPosition.y, transform.localPosition.z);
            transform.localPosition = Vector3.Lerp(transform.localPosition, position, Time.deltaTime * 1.5f);


        }
        else if (touch.phase == TouchPhase.Ended)
        {
            initTouch = new Touch();
        }

       
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "OnTriggerEnter")
        {
            if (interactable.onTriggerBool)
            {
               interactable.InteractableDone();
               interactable.Interact();

            }
        }
    }


}
