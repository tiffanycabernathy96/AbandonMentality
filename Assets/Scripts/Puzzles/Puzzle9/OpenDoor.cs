using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    Vector3 openPos = new Vector3(-4.283f, 2.006f, -6.811f);
    Quaternion openRot = Quaternion.Euler(0, 111.128f, 0);

    public void openDoor()
    {
        transform.position = openPos;
        transform.rotation = openRot;
    }
}
