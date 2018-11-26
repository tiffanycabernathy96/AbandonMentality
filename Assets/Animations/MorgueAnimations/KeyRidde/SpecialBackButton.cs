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

    // Update is called once per frame
    /*void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("I fucking clicked this buttttttttttonnnnnnn");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                //clicked on the chart

                Button backButton = rayCastHit.transform.gameObject.GetComponent<Button>();
                
                Debug.Log(backButton);
                //ClickChart chart = rayCastHit.transform.GetComponent<ClickChart>();
                if (backButton)
                {
                    backButton.close();
                }
                if (chartImg.enabled)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
                

            }
            else
            {
                Time.timeScale = 1;
                chartImg.enabled = false;
                back.enabled = false;
            }

        }
        if(Input.GetMouseButtonDown(0))
        {
            if (chartImg.enabled)
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
            Time.timeScale = 1;
            chartImg.enabled = false;
            back.enabled = false;
        }

    }*/
    public void close()
    {
        Debug.Log("Why wont you close");
        Time.timeScale = 1;
        chartImg.enabled = false;
        back.enabled = false;
    }
}
