using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorgueBed : MonoBehaviour
{

    private int m_LastIndex;
    private Animation animation;
    // Use this for initialization
    public void PlayDoorAnim()
    {
        animation = gameObject.GetComponent<Animation>();
        Debug.Log("Bed clicked");
        if (!animation.isPlaying)
        {
            if (m_LastIndex == 0)
            {
                animation.Play("morgueBedOpen");
                //animation.Play("morgueBedOpen");
                m_LastIndex = 1;
            }
            else
            {
                animation.Play("morgueBedClose");
                //animation.Play("morgueBedClose");
                m_LastIndex = 0;
            }
        }

    }


}
