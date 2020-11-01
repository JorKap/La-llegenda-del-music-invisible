using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newDatabaseConditions", menuName ="Database/DatabaseConditions")]
public class ConditionsDatabase : ScriptableObject
{
    private static ConditionsDatabase instance;

    public static ConditionsDatabase Instance
    {
        get
        {
            if (!instance)
                instance = Resources.Load<ConditionsDatabase>("DatabaseConditions");
            if (!instance)
                instance = FindObjectOfType<ConditionsDatabase>();
            if (!instance)
                Debug.LogError("AllConditions has not been created yet.  Go to Assets > Create > AllConditions.");

            return instance;
        }
        set { instance = value; }
    }
   

    public Condition[] allConditions;

    public static bool ConditionCheckIn(RequiredCondition requiredCondition)
    {
        Condition[] conditions = Instance.allConditions;
        Condition selectedCondition = null;
        for (int i = 0; i < conditions.Length; i++)
        {
            if(conditions[i].description == requiredCondition.description)
            {
                selectedCondition = conditions[i];
            }
        }

        if(!selectedCondition)
            return false;

        return selectedCondition.satisfied == requiredCondition.satisfied;
    }
}
