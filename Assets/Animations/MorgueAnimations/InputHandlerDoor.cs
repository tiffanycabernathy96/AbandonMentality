using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandlerDoor : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                //Debug.Log("Mouse Click");
                MorgueDoor door = rayCastHit.transform.GetComponent<MorgueDoor>();
                if (door)
                {
                    Debug.Log("Play animation");
                    door.PlayDoorAnim();
                }

            }
        }

    }
}
