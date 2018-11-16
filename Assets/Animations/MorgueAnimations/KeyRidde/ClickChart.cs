using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickChart : MonoBehaviour {

    public Image chartImg;
    public Image back;
    //public GameObject chart;
	// Use this for initialization
	void Start () {
        chartImg.enabled = false;
        back.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                //clicked on the chart

                ClickChart chart = rayCastHit.transform.gameObject.GetComponent<ClickChart>();
                //ClickChart chart = rayCastHit.transform.GetComponent<ClickChart>();
                if(chart)
                {
                    chartImg.enabled = !chartImg.enabled;
                    back.enabled = !back.enabled;
                }
                

            }
           
        }
        if(Input.GetMouseButtonDown(0))
        {
            chartImg.enabled = false;
            back.enabled = false;
        }
        
	}

    
}
