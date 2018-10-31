using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    private const int SLOTS = 9;

    private List<IInventoryItem> nItems = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public void AddItem(IInventoryItem item)
    {
        if(nItems.Count < SLOTS)
        {
            Debug.Log("this shit doesnt matter atm");
            //Dont really understand this shit 
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if(collider.enabled)
            {
                collider.enabled = false;

                nItems.Add(item);

                item.pickUp();

                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }
}
