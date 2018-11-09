using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Maps : MonoBehaviour {

    public Button leftButton;
    public Button rightButton;
    public Button backButton;
    public List<Image> floors; //0 is 1st, 1 is 2nd, 2 is basement

    private int currentFloorDisplayed = -1;

    public void DisplayMaps(float playerYLocation)
    {
        leftButton.enabled = true;
        rightButton.enabled = true;
        backButton.enabled = true;
        //Determine What Floor the User is on.
        int test = 0;
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
