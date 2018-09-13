using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {
    //This is used in order to determine where the character should move when the puzzle is clicked
    public GameObject positionObject;
    public List<Piece> puzzlePieces;

    public Transform GetTransform()
    {
        return positionObject.transform;
    }
    
}
