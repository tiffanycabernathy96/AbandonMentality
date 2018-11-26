using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button0 : Puzzle {


    public GameObject MorgueDoorAnswer;
    public GameObject MorgueBedAnswer;
    //public GameObject oneBlock;
    //public GameObject zeroBlock;
    public Puzzle box;
    public string answer;
    public bool doorIsOpening;
    public bool bedIsOpening;
    public bool solved;

    // Update is called once per frame
    void Update()
    {
        if(!solved)
        {
            if (doorIsOpening == true)
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
            }
            else
            {
                doorIsOpening = false;
                bedIsOpening = false;
            }

            if (bedIsOpening == true)
            {
                Animation morgueBed = MorgueBedAnswer.GetComponent<Animation>();
                morgueBed.Play("morgueBedOpen");
                bedIsOpening = false;
                solved = true;
            }

            //shouldnt this be specific for this obj?????
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayCastHit;

                if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
                {
                    //Debug.Log("Mouse Click");
                    //MorgueDoor door = rayCastHit.transform.GetComponent<MorgueDoor>();
                    Button0 zero = rayCastHit.transform.GetComponent<Button0>();
                    if (zero)
                    {
                        box.MorgueAnswer += "0";
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
}
