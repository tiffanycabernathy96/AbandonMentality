using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    private int m_LastIndex;
    private Animation animation;
    // Use this for initialization
    public void PlayDoorAnim()
    {
        animation = gameObject.GetComponent<Animation>();

        if (!animation.isPlaying)
        {
            if (m_LastIndex == 0)
            {
                animation.Play("morgueDoorOpen");
                //animation.Play("morgueBedOpen");
                m_LastIndex = 1;
            }
            else
            {
                animation.Play("morgueDoorClose");
                //animation.Play("morgueBedClose");
                m_LastIndex = 0;
            }
        }

    }


}
