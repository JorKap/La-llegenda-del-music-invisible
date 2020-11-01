using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public GameObject objectToFadeOut;
    Animator animator;
    Renderer render;
    Renderer renderButton;
    Color colorFade;
    Color colorFadeButton;
    bool fade;
    private void Start()
    {
        render = objectToFadeOut.GetComponent<Renderer>();
        renderButton = GetComponent<Renderer>();
        //animator = button3D.GetComponent<Animator>();
        colorFade = render.material.color;
        colorFadeButton = renderButton.material.color;
    }

    private void OnMouseDown()
    {
        fade = true;
       // animator.SetBool("OnButton" , true);
    }
    private void Update()
    {
        if (fade)
        {
            Debug.Log("Fade");
            colorFade.a -= Time.deltaTime * 2f;
            render.material.color = colorFade;

            colorFadeButton.a -= Time.deltaTime * 2f;
            renderButton.material.color = colorFadeButton;
            if(colorFade.a == 0)
            {
                objectToFadeOut.SetActive(false);
                
            }
        }
    }
}
