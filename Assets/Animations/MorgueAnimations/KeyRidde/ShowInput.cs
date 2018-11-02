using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInput : Puzzle {

    public TextMesh  playerInput;
    public Puzzle box;

    private void Start()
    {
        playerInput.text = box.MorgueAnswer;
    }
    // Update is called once per frame
    void Update () {

        playerInput.text = box.MorgueAnswer;
		
	}
}
