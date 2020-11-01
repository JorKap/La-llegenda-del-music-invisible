using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsCamera : MonoBehaviour
{
    public PlayerRotation playerRotation;
    public PlayerManager playerManager;
    [HideInInspector]
    public GameObject model;

    public Transform rig;
    public float sensitivity = 3f;

    Quaternion modelRot;
    Quaternion rigRot;

    float YSensitivity = 2;
    float XSensitivity = 2;

    private void Update()
    {


        if (Input.touchCount > 0)
        {
            if (model == null)
                return;
            modelRot = model.transform.rotation;
            rigRot = rig.rotation;
            Touch touch = Input.GetTouch(0);
            
             if (touch.phase == TouchPhase.Moved)
            {
                playerRotation.enabled = false;
               float deltaX = touch.deltaPosition.x;
               float deltaY = touch.deltaPosition.y;
               float rotY = deltaX * Time.deltaTime * YSensitivity ;
               float rotX = deltaY * Time.deltaTime * XSensitivity ;

               
                modelRot *= Quaternion.Euler(0f, -rotY, 0f);
                rigRot *= Quaternion.Euler(rotX, 0f, 0f);

                rigRot = ClampRotationAroundXAxis(rigRot);


                model.transform.rotation = modelRot;
                rig.transform.rotation = rigRot;


            }if(touch.phase == TouchPhase.Ended)
            {
                playerRotation.enabled = true;

            }


        }
    }
    

    Quaternion ClampRotationAroundXAxis(Quaternion q)
    {
        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1.0f;

        float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

        angleX = Mathf.Clamp(angleX, -80, 80);

        q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

        return q;
    }

    public void Close()
    {
        Destroy(model.gameObject);
        rig.rotation = Quaternion.identity;
        gameObject.SetActive(false);
        GameManager.instance.observerCameraButton.SetActive(false);

        //GameManager.instance.currentNode.SetReachableNodes(true);
        //GameManager.instance.currentNode.col.enabled = true;
        GameManager.instance.currentItemDrag.gameObjectInstantiated = false;
        playerManager.enabled = true;

    }
}
