using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchButtons : MonoBehaviour
{
    public GameObject button;
    Animator animator;
    public GameObject emissionLightsControl;
    EmissionControl emissionControl;
    public GameObject lightObject;

    // Start is called before the first frame update
    void Start()
    {
        animator = button.GetComponent<Animator>();
        emissionControl = emissionLightsControl.GetComponent<EmissionControl>();
    }

    private void OnMouseDown()
    {
        animator.enabled = true;
        StopAnimation();
        emissionControl.onEmission = true;
        lightObject.SetActive(true);

    }
    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(1f);
        animator.enabled = false;
    }
}
