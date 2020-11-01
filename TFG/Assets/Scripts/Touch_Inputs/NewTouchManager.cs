using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTouchManager : MonoBehaviour
{
    GameObject gObj = null;
    Plane objPlane;
    Vector3 mouseOffset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray mouseRay = GenerateMouseRay(Input.GetTouch(0).position);
                RaycastHit hit;
                if(Physics.Raycast(mouseRay.origin, mouseRay.direction, out hit))
                {
                    gObj = hit.transform.gameObject;
                    objPlane = new Plane(Camera.main.transform.forward * -1, gObj.transform.position);

                    Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    float rayDistance;
                    objPlane.Raycast(mRay, out rayDistance);

                    mouseOffset = gObj.transform.position - mRay.GetPoint(rayDistance);
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Moved && gObj)
            {
                Ray mRay = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                float rayDistance;
                if(objPlane.Raycast(mRay, out rayDistance))
                {
                    gObj.transform.position = mRay.GetPoint(rayDistance) + mouseOffset;
                }
            }
            else if(Input.GetTouch(0).phase == TouchPhase.Ended && gObj)
            {
                gObj = null;
            }
        }

        
    }
    Ray GenerateMouseRay(Vector3 touchPos)
    {
        Vector3 mousePosFar = new Vector3(touchPos.x, touchPos.y, Camera.main.farClipPlane);
        Vector3 mousePosNear = new Vector3(touchPos.x, touchPos.y, Camera.main.nearClipPlane);
        Vector3 mousePosF = Camera.main.ScreenToWorldPoint(mousePosFar);
        Vector3 mousePosN = Camera.main.ScreenToWorldPoint(mousePosNear);
        Debug.DrawRay(mousePosN, mousePosF - mousePosN, Color.green);

        Ray mr = new Ray(mousePosN, mousePosF - mousePosN);
        return mr;
    }
}
