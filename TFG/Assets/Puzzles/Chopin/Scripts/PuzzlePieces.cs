using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePieces : MonoBehaviour
{
    public float correctRotation = 0f;
    public bool isPlaced = false;
    int[] rotations = { 0, 90, 270, 360 };

    PuzzleManager puzzleManager;
    Vector3 rot;

    private void Awake()
    {
        correctRotation = Mathf.Floor(transform.eulerAngles.z);
        puzzleManager = transform.parent.GetComponent<PuzzleManager>();
        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);
      
    }
   
    private void OnMouseDown()
    {
        transform.Rotate(0, 0, 90);

       
        if(Mathf.Floor(transform.eulerAngles.z) == correctRotation && !isPlaced)
        {
            isPlaced = true;
           
        }
        else if (Mathf.Floor( transform.eulerAngles.z) != correctRotation && isPlaced)
        {
            isPlaced = false;
        
        }
        puzzleManager.UpdateIsPlaced();
    }
}
