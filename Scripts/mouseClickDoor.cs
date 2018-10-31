using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouseClickDoor : MonoBehaviour
{

    private bool doorOpen = false;
    private float animationFinished = 0;

    public void OnMouseUp()
    {
        Animation animation = gameObject.GetComponent<Animation>();

        Debug.Log("Ive been clicked");

        if (Time.time > animationFinished)
        {
            if (doorOpen)
            {
                animation.Play("closeDoor");
            }
            else
            {
                animation.Play("openDoor");
            }

            animationFinished = Time.time + 1;
            doorOpen = !doorOpen;
        }
    }
}

