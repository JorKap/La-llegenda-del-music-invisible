using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBaseManager : MonoBehaviour
{
    public ConditionsDatabase databaseConditions;

    private void Awake()
    {
        for (int i = 0; i < databaseConditions.allConditions.Length; i++)
        {
            databaseConditions.allConditions[i].satisfied = false;
        }
    }
}
