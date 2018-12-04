﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Puzzle : MonoBehaviour {
    //This is used in order to determine where the character should move when the puzzle is clicked
    public GameObject positionObject;
    //This needs to contain all the pieces needed to complete this puzzle. 
    public List<Piece> puzzlePieces;
    //Has the player found and interacted with this puzzle yet?
    public bool puzzleActivated = false;
    //Has the player found and completed this puzzle yet?
    public bool puzzleCompleted = false;

    //Simple function to return the position of the object. 
    public Transform GetTransform()
    {
        return positionObject.transform;
    }

    //If you are going use canvas for your puzzle this can be used. 
    public Image puzzleImage;
    public Image backImage;
    public Material imageMaterial;
    public int puzzleScene = -1;
    
    public void OpenPuzzle()
    {
        if(puzzleImage && !puzzleCompleted)
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
            //TODO Load Scene
        }
    }
}
