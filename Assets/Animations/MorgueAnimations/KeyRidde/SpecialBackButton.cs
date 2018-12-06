using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBackButton : MonoBehaviour
{

    public Image chartImg;
    public Image back;
    public bool clicked;
    //public GameObject chart;
    // Use this for initialization
    void Start()
    {
        chartImg.enabled = false;
        back.enabled = false;
    }

   
    public void close()
    {
        Time.timeScale = 1;
        chartImg.enabled = false;
        back.enabled = false;
    }
}
