using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class mouseClickMorgueDoor : MonoBehaviour
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
                Debug.Log("open the doooooor");
                animation.Play("morgueDoorClose");
                //animation.Play("morgueBedClose");
            }
            else
            {
                animation.Play("morgueDoorOpen");
                //animation.Play("morgueBedOpen");
            }

            animationFinished = Time.time + 1;
            doorOpen = !doorOpen;
        }
    }
}

