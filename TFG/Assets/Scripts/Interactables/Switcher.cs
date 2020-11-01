using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switcher : InteractableBeats
{
    public bool state;
    //event setup
    public delegate void OnStateChange();
    public event OnStateChange Change;

    public override void Interact()
    {
        state = !state;
        Change?.Invoke();
    }
}
