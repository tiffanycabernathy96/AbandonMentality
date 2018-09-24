using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
}
