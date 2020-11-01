using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoubleClick : MonoBehaviour
{
    private float firstClickTime, timeBetweenClicks;
    private bool coroutineAllowed;
    private int clickCounter;
   // public Text result;
    public bool doubleClickDone = false;

    // Start is called before the first frame update
    void Start()
    {
        firstClickTime = 0f;
        timeBetweenClicks = 0.4f;
        clickCounter = 0;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        //doubleClickDone = false;

        if (Input.GetMouseButtonDown(0))
            clickCounter += 1;

        if(clickCounter == 1 && coroutineAllowed)
        {
            firstClickTime = Time.time;
            StartCoroutine(DoubleClickDetection());
        }

        //if(Input.GetMouseButtonDown(0))
        //    result.text = "No Click";

    }

    private IEnumerator DoubleClickDetection()
    {
        coroutineAllowed = false;
        while(Time.time < firstClickTime + timeBetweenClicks)
        {
            if(clickCounter == 2)
            {
               // Debug.Log("DoubleClick");
                //result.text = "DoubleClick";
                doubleClickDone = true;
                break;
            }
            doubleClickDone = false;
            yield return new WaitForEndOfFrame();
        }

       
        clickCounter = 0;
        firstClickTime = 0f;
        coroutineAllowed = true;
    }
}
