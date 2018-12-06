using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button0 : Puzzle
{
    public GameObject MorgueDoorAnswer;
    public GameObject MorgueBedAnswer;

    public Puzzle box;
    public string answer;
    public bool doorIsOpening;
    public bool bedIsOpening;
    public bool solved;

    public Button1 oneButton;

    // Update is called once per frame
    void Update()
    {
        if(!solved)
        {
            if (doorIsOpening == true)
            {
                Animation morgueDoor = MorgueDoorAnswer.GetComponent<Animation>();
                morgueDoor.Play("morgueDoorOpen");
                doorIsOpening = false;
                oneButton.doorIsOpening = false;
            }
            else
            {
                doorIsOpening = false;
                bedIsOpening = false;
                oneButton.doorIsOpening = false;
                oneButton.bedIsOpening = false;
            }

            if (bedIsOpening == true)
            {
                Animation morgueBed = MorgueBedAnswer.GetComponent<Animation>();
                morgueBed.Play("morgueBedOpen");
                bedIsOpening = false;
                oneButton.bedIsOpening = false;
                solved = true;
                oneButton.solved = true;
            }
            
        }
        
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                Debug.DrawRay(ray.origin, ray.direction, Color.green);
                Button0 zero = rayCastHit.transform.GetComponent<Button0>();
                if (zero)
                {
                    box.morgueAnswer += "0";
                    Debug.Log(box.MorgueAnswer());
                }

                if (box.MorgueAnswer() == "011100110110111101101110")
                {
                    doorIsOpening = true;
                    bedIsOpening = true;
                }

            }
        }
    }
}
