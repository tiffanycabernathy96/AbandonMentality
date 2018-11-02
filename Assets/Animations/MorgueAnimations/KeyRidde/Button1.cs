using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button1 : Puzzle {


    public GameObject MorgueDoorAnswer;
    public GameObject MorgueBedAnswer;
    public Puzzle box;
    public bool doorIsOpening;
    public bool bedIsOpening;
	
	// Update is called once per frame
	void Update () {
        if(doorIsOpening == true)
        { 
            Animation morgueDoor = MorgueDoorAnswer.GetComponent<Animation>();
            morgueDoor.Play("morgueDoorOpen");
            
            /*  if(bedIsOpening == true)
              {
                  Animation morgueBed = MorgueBedAnswer.GetComponent<Animation>();
                  morgueBed.Play("morgueBedOpen");
              }
              doorIsOpening = false;
              bedIsOpening = false;*/
            Debug.Log("set to false");
            doorIsOpening = false;
            bedIsOpening = false;
        }
        else
        {
            doorIsOpening = false;
            bedIsOpening = false;
        }

		if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
           
                Button1 one = rayCastHit.transform.GetComponent<Button1>();
                if (one)
                {
                    box.MorgueAnswer += "1";
                    Debug.Log(box.test());
                }

                if (box.test() == "011100110110111101101110")
                {
                    doorIsOpening = true;
                    bedIsOpening = true;
                }

            }

        }
	}
}
