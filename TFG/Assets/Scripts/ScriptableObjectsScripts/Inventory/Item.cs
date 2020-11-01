using UnityEngine;

// This simple script represents Items that can be picked
// up in the game.  The inventory system is done using
// this script instead of just sprites to ensure that items
// are extensible.
[CreateAssetMenu]
public class Item: ScriptableObject
{
    public new string name = "New Item";
    public Sprite icon = null;
    public GameObject gameObject = null;

    public virtual void Use()
    {
        Debug.Log("Using " + name);
    }
}
