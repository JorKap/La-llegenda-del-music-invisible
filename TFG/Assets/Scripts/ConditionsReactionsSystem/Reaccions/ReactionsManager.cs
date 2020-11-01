using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactionsManager : MonoBehaviour
{
    public Reactions[] reactions = new Reactions[0];      // Array of all the Reactions to play when React is called.


    public void React()
    {
        // Go through all the Reactions and call their React function.
        for (int i = 0; i < reactions.Length; i++)
        {
           
                reactions[i].React(this);
        }
    }
}
