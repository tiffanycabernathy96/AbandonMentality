﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, IInventoryItem {

    public string Name
    {
        get
        {
            return "Key";
        }
    }

    public Sprite _Image = null;
    
    public Sprite Image
    {
        get
        {
            return _Image;
        }
    }

    public void pickUp()
    {
        Debug.Log("pick me UP!!!!");
        Destroy(this.gameObject);
    }
}
