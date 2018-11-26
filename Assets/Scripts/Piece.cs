using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour {
    public bool found = false;
    private Collider navMeshAgent;
    private Collider collider;
    void Awake()
    {
        collider = GetComponent<BoxCollider>();    
    }
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
    private void Update()
    {
        if (found)
            DestroyGameObj();
        //TODO put in inventory
    }
}
