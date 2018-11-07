using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    List<Image> inventoryItems = new List<Image>();
    Image[] inventorySlots = new Image[35];
	// Use this for initialization
	void Start () {
        inventorySlots = GetComponentsInChildren<Image>();
        
        int test = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void addItemToInventory(Image item)
    {

    }
    void removeItemFromInventory(Image item)
    {

    }
}
