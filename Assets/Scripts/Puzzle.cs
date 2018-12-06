using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puzzle : MonoBehaviour {
    public string morgueAnswer;
    //This needs to contain all the pieces needed to complete this puzzle. 
    public List<Piece> puzzlePieces;
    //Has the player found and interacted with this puzzle yet?
    public bool puzzleActivated = false;
    //Has the player found and completed this puzzle yet?
    public bool puzzleCompleted = false;

    public string puzzleUnActivactedString;
    public string MorgueAnswer()
    {
        return morgueAnswer;
    }
    //If you are going use canvas for your puzzle this can be used. 
    public Image puzzleImage;
    public Image backImage;
    public Material imageMaterial;
    public int puzzleScene = -1;
    
    public void OpenPuzzle()
    {
        if(puzzleActivated && puzzleImage && !puzzleCompleted)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            Canvas currentCanvas = FindObjectOfType<Canvas>();
            currentCanvas.GetComponent<CanvasGroup>().interactable = true;
            puzzleImage.enabled = true;
            puzzleImage.material = imageMaterial;
            backImage.enabled = true;
            Time.timeScale = 0;
        }
        else if(puzzleScene != -1 && !puzzleCompleted)
        {
            LoadScene loader = GetComponent<LoadScene>();
            if(loader)
            {
                loader.LoadSceneByIndex(puzzleScene);
            }
        }
    }
}
