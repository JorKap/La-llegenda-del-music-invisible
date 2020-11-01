using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextReaction : Reactions
{
    public string message;                      // The text to be displayed to the screen.
    public Color textColor = Color.white;       // The color of the text when it's displayed (different colors for different characters talking).
    public bool textEnable;

    TextManager textManager;            // Reference to the component to display the text.

    private void Awake()
    {
        textManager = FindObjectOfType<TextManager>();
    }

    //private void Start()
    //{
    //    textManager = FindObjectOfType<TextManager>();

    //}


    protected override void ImmediateReaction()
    {
        if(textEnable)
            textManager.DisplayText(message, textColor);
        
    }

}


