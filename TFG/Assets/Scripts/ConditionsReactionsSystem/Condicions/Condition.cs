using UnityEngine;

[CreateAssetMenu(fileName = "new MyCondition", menuName = "Conditions/Condition")]
public class Condition : ScriptableObject
{
    public string description;      // A description of the Condition, for example 'BeamsOff'.
    public bool satisfied;          // Whether or not the Condition has been satisfied, for example are the beams off?

}

