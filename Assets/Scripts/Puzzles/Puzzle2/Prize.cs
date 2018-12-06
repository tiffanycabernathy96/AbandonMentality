//Copyright Nov 2018 Denise S Davis and Tiffany Abernathy

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Prize : MonoBehaviour {
    public List<GameObject> shapes;
    public Material winMaterial;
    public Material[] materials;
    public Text winText;
    public LoadScene loader;
    private bool complete = false;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < shapes.Count; i++)
        {
            Animation anim = shapes[i].GetComponent<Animation>();
            anim.Play();
        }
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if(!complete)
        {
            bool won = true;
            for (int i = 0; i < shapes.Count; i++)
            {
                Material m_Material = shapes[i].GetComponent<Renderer>().sharedMaterial;
                if (winMaterial != m_Material)
                {
                    won = false;
                }
            }
            if (won && !complete)
            {
                won = false;
                complete = true;
                Time.timeScale = 1;
                StartCoroutine(ShowMessage(2));
            }
        }
        
	}
    IEnumerator ShowMessage(float delay)
    {
        winText.enabled = true;
        yield return new WaitForSeconds(delay);
        winText.enabled = false;
        GameData.DayRoomPuzzle = true;
        Time.timeScale = 1;
        loader.LoadSceneByIndex(3);
    }
}
