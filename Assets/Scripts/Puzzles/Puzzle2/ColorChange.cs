//Copyright Nov 2018 Denise S Davis

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorChange : MonoBehaviour
{

    public Material[] materials;
    public Renderer rend_to;

    private int i_to, i_from;
    private Renderer rend_from;

    void Start()
    {
        rend_from = GetComponent<Renderer>();
      //  rend.enabled = true;
    }

    void OnMouseDown()
    {
        if (materials.Length == 0)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            i_to = System.Array.IndexOf(materials, rend_to.sharedMaterial);
            i_from = System.Array.IndexOf(materials, rend_from.sharedMaterial);

            if (i_to== materials.Length-1 )
               {
                i_to = -1;
            } 
            if (i_from == materials.Length-1)
            {
                i_from = -1;
            }
            
            rend_to.sharedMaterial = materials[i_to + 1];
            rend_from.sharedMaterial = materials[i_from + 1];
           }
    }
}
