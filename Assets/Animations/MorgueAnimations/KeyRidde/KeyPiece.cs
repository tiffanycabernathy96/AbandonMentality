using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPiece : Piece {
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {

                KeyPiece key = rayCastHit.transform.GetComponent<KeyPiece>();

                if (key)
                {
                    Debug.Log("got the key!!");
                    key.DestroyGameObj();
                    
                }
            }

        }
    }
}
