using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PlayerRotation : MonoBehaviour
{
    public float speedRotation = 0.5f;
    public float slerpSpeed = 0.5f;
    float rotX;
    float rotY;
    float deltaX;
    float deltaY;
    Vector3 startScreenMousePosition;
    Quaternion xyAxis;

    public static float minX;
    public static float maxX;
    public static float minY;
    public static float maxY;
    public RotationClampedValues clampedValues;
    string targetName;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {

                startScreenMousePosition = Input.mousePosition;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                deltaX = touch.deltaPosition.x;
                deltaY = touch.deltaPosition.y;
                if (targetName == "LookAt")
                {
                    rotX -= deltaY * Time.deltaTime * speedRotation;
                    rotY += deltaX * Time.deltaTime * speedRotation;
                    clampedValues = new RotationClampedValues(-20, 20, -45, 45);
                }
                if (targetName == "Panoramic")
                {
                    rotX += deltaY * Time.deltaTime * speedRotation;
                    rotY -= deltaX * Time.deltaTime * speedRotation;
                    clampedValues = new RotationClampedValues(-20, 20, 0, 0);


                }
                if(targetName == "Detail")
                {
                    rotX -= deltaY * Time.deltaTime * speedRotation;
                    rotY += deltaX * Time.deltaTime * speedRotation;
                    clampedValues = new RotationClampedValues(-20, 20, -45, 45);
                }

                rotX = Mathf.Clamp(rotX, clampedValues.minX, clampedValues.maxX);

                if (clampedValues.minY != 0 || clampedValues.maxY != 0)
                    rotY = Mathf.Clamp(rotY, clampedValues.minY, clampedValues.maxY);

                xyAxis = Quaternion.Euler(rotX, rotY, 0);

            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                deltaX = 0;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                touch = new Touch();
            }
        }
        

        transform.parent.transform.localRotation = Quaternion.Slerp(transform.parent.transform.localRotation, xyAxis, Time.deltaTime * slerpSpeed);

    }

    public static void SetRotationClampValues(float _minX, float _maxX, float _minY, float _maxY)
    {
        minX = _minX;
        maxX = _maxX;
        minY = _minY;
        maxY = _maxY;
    }

    public void GetTargetName(string _targetName)
    {
        targetName = _targetName;
    }

    public void SetRotationValues(float _rotX, float _rotY, Quaternion _xyAxis)
    {
        rotX = _rotX;
        rotY = _rotY;
        xyAxis = _xyAxis;
    }


}










