using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageViewer : InteractableBeats
{
    public Sprite picture;

    public override void Interact()
    {
        GameManager.instance.iVCanvas.Activate(picture);

    }
}
