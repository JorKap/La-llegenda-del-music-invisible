using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class PuzzleManager : MonoBehaviour
{
    public GameObject parentPuzzle;
    public GameObject[] pieces;
    public GameObject puzzleCamera;
    public GameObject button;

    ReactionsManager puzzleDone;
    PuzzlePieces[] puzzlePieces;
    int[] piecesZRotation;
    int totalPieces;
    // public Button playAgainButton;
    //[SerializeField]
    //Text win;
    Renderer[] render;
    Color[] colorFade;
    bool on;
    bool off;
   // Scene scene;

    // Start is called before the first frame update
    void Start()
    {
        puzzleDone = GetComponent<ReactionsManager>();

       // scene = SceneManager.GetActiveScene();
        totalPieces = parentPuzzle.transform.childCount;
        piecesZRotation = new int[totalPieces];
        pieces = new GameObject[totalPieces];
        puzzlePieces = new PuzzlePieces[totalPieces];
        render = new Renderer[totalPieces];
        colorFade = new Color[totalPieces];

        //pieces = transform.GetComponentsInChildren<PipeScript>();
        for (int i = 0; i < totalPieces; i++)
        {
            pieces[i] = parentPuzzle.transform.GetChild(i).gameObject;
            pieces[i].GetComponent<Collider2D>().enabled = true;
            //Retornem la opacitat amb alfa
            render[i] = pieces[i].GetComponent<SpriteRenderer>();
            //colorFade[i] = render[i].material.color;
            //colorFade[i].a = 1;
            //render[i].material.color = colorFade[i];

            piecesZRotation[i] = (int)pieces[i].transform.eulerAngles.z;
            //Debug.Log("pieces: " + pieces[i].name + " " + piecesZRotation[i]);
            puzzlePieces[i] = pieces[i].GetComponent< PuzzlePieces>();
            if (Mathf.Floor( piecesZRotation[i]) == 0 )
            {
                puzzlePieces[i].isPlaced = true;
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (correctRotation == totalPieces && !off)
        {
            // win.text = "You Win";
            for (int i = 0; i < totalPieces; i++)
            {
                colorFade[i] = render[i].material.color;
                colorFade[i].a -= Time.deltaTime;
                render[i].material.color = colorFade[i];

            }
            StartCoroutine(StopCamera());
            puzzleDone.React();
            off = true;
        }
        if (on)
        {
            for (int i = 0; i < totalPieces; i++)
            {
                colorFade[i] = render[i].material.color;
                colorFade[i].a = 1;
                render[i].material.color = colorFade[i];
            }
            on = false;
        }
    }
    int correctRotation = 0;
    public void UpdateIsPlaced()
    {
        correctRotation = 0;
        for (int i = 0; i < totalPieces; i++)
        {
           // Debug.Log("pieces: " + pieces[i].name + " " + pipeScripts[i].isPlaced);
            if (puzzlePieces[i].isPlaced)
            {
                correctRotation += 1;
            }
            Debug.Log(correctRotation);

        }
        if (correctRotation == totalPieces)
        {
           // win.text = "You Win";
            for (int i = 0; i < totalPieces; i++)
            {
                pieces[i].GetComponent<Collider2D>().enabled = false;
               
            }
            //  playAgainButton.gameObject.SetActive(true);
            Debug.Log("You Win");
        }
    }

    //public void PlayAgain()
    //{
    //    SceneManager.LoadScene(scene.buildIndex);
    //}

    IEnumerator StopCamera()
    {
       
        yield return new WaitForSeconds(1);
        puzzleCamera.SetActive(false);
        on = true;
        button.SetActive(true);
      //  puzzleDone.React();
        
    }
}
