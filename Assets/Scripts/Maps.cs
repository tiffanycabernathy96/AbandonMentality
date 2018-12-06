using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour {

    public Image leftButton;
    public Image rightButton;
    public Image backButton;
    public List<Image> floors; //0 is 1st, 1 is 2nd, 2 is basement
    public float[] floorPositions = {1.051798f, 4.843465f, -2.823202f};
    public CharacterControllerMovement character;


    private int currentFloorDisplayed = -1;

    public void DisplayMaps(float playerYLocation)
    {
        leftButton.enabled = true;
        rightButton.enabled = true;
        backButton.enabled = true;
        //Determine What Floor the User is on.
        if(System.Math.Abs(playerYLocation -floorPositions[0]) < 1e-3)
        {
            //First Floor
            floors[0].enabled = true;
            currentFloorDisplayed = 0;
        }
        else if(System.Math.Abs(playerYLocation - floorPositions[1]) < 1e-3)
        {
            //Second Floor
            floors[1].enabled = true;
            currentFloorDisplayed = 1;
        }
        else if(System.Math.Abs(playerYLocation - floorPositions[2]) < 1e-3)
        {
            //Basement
            floors[2].enabled = true;
            currentFloorDisplayed = 2;
        }
        
    }
    public void HideMaps()
    {
        leftButton.enabled = false;
        rightButton.enabled = false;
        backButton.enabled = false;
        foreach (Image floor in floors)
        {
            floor.enabled = false;
        }
        character.MovementController(true);
    }
    public void ShowNextFloor(int direction)
    {
        //0 is go down 
        //1 is go up. 
        floors[currentFloorDisplayed].enabled = false;
        if(direction == 0)
        {
            currentFloorDisplayed -= 1;
            if (currentFloorDisplayed < 0)
                currentFloorDisplayed = 2;
        }
        else
        {
            currentFloorDisplayed += 1;
            if (currentFloorDisplayed > 2)
                currentFloorDisplayed = 0;
        }
        floors[currentFloorDisplayed].enabled = true;
    }
}
