using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDelete : Puzzle
{

    public Puzzle box;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                ButtonDelete del = rayCastHit.transform.GetComponent<ButtonDelete>();
                if (del)
                {
                    Debug.Log("should be backspace 1");
                    box.morgueAnswer = box.morgueAnswer.Remove(box.morgueAnswer.Length - 1);
                    Debug.Log(box.MorgueAnswer());
                }
            }
        }
    }
}
