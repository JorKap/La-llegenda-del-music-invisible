using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampImage : MonoBehaviour
{
    public Image placeHolder;
    Vector3 imagePos;
    private void Start()
    {
        placeHolder.gameObject.SetActive(false);
    }
    private void Update()
    {
       
        imagePos = Camera.main.WorldToScreenPoint(this.transform.position);
        placeHolder.transform.position = imagePos;
    }
}
