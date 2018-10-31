using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(1))
        {
            //pick up the object
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                
                Key circle = rayCastHit.transform.gameObject.GetComponent<Key>();
                circle.pickUp();

            }
        }
	}
}
