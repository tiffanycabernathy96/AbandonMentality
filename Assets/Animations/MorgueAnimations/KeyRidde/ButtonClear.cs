using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClear : Puzzle
{

    public Puzzle box;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                ButtonClear clear = rayCastHit.transform.GetComponent<ButtonClear>();
                
                if (clear)
                {
                    box.morgueAnswer = "";
                }
            }

        }
    }
}
