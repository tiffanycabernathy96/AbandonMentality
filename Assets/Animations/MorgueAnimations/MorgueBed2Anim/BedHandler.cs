using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedHandler : MonoBehaviour
{

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rayCastHit;

            if (Physics.Raycast(ray.origin, ray.direction, out rayCastHit, Mathf.Infinity))
            {
                Debug.Log("Mouse Click");
                BedAnim bed = rayCastHit.transform.GetComponent<BedAnim>();
                if (bed)
                {
                    Debug.Log("Play animation");
                    bed.PlayDoorAnim();
                }

            }
        }

    }
}
