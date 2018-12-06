using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour {
    public bool found = false;
    public Material imageMat;
    public string pieceName;
    public void DestroyGameObj()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Camera" && found)
        {
            Destroy(gameObject);
        }
    }
}
