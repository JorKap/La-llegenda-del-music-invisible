using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReaction : Reactions
{
    public GameObject gameObjectAnimated;
    Animator animator;   // The Animator that will have its trigger parameter set.


    

    private void Start()
    {
        animator = gameObjectAnimated.GetComponent<Animator>();
    }


    protected override void ImmediateReaction()
    {
        animator.SetBool("Open", false);
        StartCoroutine(StopAnimation());

    }

    private IEnumerator StopAnimation()
    {
        yield return new WaitForSeconds(2f);
       // animator.SetBool("Close", false);

        animator.enabled = false;
        
    }
}
