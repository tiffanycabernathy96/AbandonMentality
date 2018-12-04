//Copyright Nov 2018 Denise S Davis and Tiffany Abernathy

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prize : MonoBehaviour {
    public List<GameObject> shapes;
    public Material winMaterial;
    public Material[] materials;
    public Text winText;
    public LoadScene loader;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool won = true;
		for(int i = 0; i < shapes.Count; i++)
        {
            Material m_Material = shapes[i].GetComponent<Renderer>().sharedMaterial;
            if (winMaterial != m_Material)
            {
                won = false;
            }
        }
        if(won)
        {
            StartCoroutine(ShowMessage(2));
        }
	}
    IEnumerator ShowMessage(float delay)
    {
        winText.enabled = true;
        yield return new WaitForSeconds(delay);
        loader.LoadSceneByIndex(3);
    }
}
