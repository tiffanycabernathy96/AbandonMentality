using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Image inventoryImage;
    public Image[] inventorySlots = new Image[32];
    public Text hexCodeDigits;
    public string[] pieceNames = new string[32];
    int emptySlot = 1;
    public void addItemToInventory(Material item, string itemName)
    {
        int inventorySlot = findNextEmptyInventorySlot();
        inventorySlots[inventorySlot].material = item;
        pieceNames[inventorySlot] = itemName;
    }
    public void removeItemFromInventory(Material item)
    {
        int indexOfRemoved = 0;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].material == item)
            {
                indexOfRemoved = i;
                break;
            }
        }
        for(int i = indexOfRemoved; i < emptySlot-1; i++)
        {
            inventorySlots[i].material = inventorySlots[i + 1].material;
            pieceNames[i] = pieceNames[i + 1];
            inventorySlots[emptySlot].enabled = false;
            pieceNames[emptySlot] = "";
        }
        emptySlot--;
    }
    public void removeItemFromInventory(string item)
    {
        int indexOfRemoved = 0;
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (pieceNames[i] == item)
            {
                indexOfRemoved = i;
                break;
            }
        }
        for (int i = indexOfRemoved; i < emptySlot - 1; i++)
        {
            inventorySlots[i].material = inventorySlots[i + 1].material;
            pieceNames[i] = pieceNames[i + 1];
            inventorySlots[emptySlot].enabled = false;
            pieceNames[emptySlot] = "";
        }
        emptySlot--;
    }
    public void replaceItemInInventory(Material item1, Material item2)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            if (inventorySlots[i].material == item1)
            {
                inventorySlots[i].material = item2;
                break;
            }
        }
    }
    public bool itemExists(string itemName)
    {
        bool exists = false;
        foreach(string item in pieceNames)
        {
            if (item == itemName)
                exists = true;
        }
        return exists;
    }
    public int findNextEmptyInventorySlot()
    {
        emptySlot++;
        return emptySlot-1;
    }
    public void enableInventory()
    {
        inventoryImage.enabled = true;
        hexCodeDigits.enabled = true;
        for (int i = 0; i < emptySlot; i++)
        {
            inventorySlots[i].enabled = true;
        }
            
    }
    public void showNewItem()
    {
        StartCoroutine(ShowInventory(2));
    }

    IEnumerator ShowInventory(float delay)
    {
        enableInventory();
        yield return new WaitForSeconds(delay);
        disableInventory();
    }
    public void disableInventory()
    {
        inventoryImage.enabled = false;
        hexCodeDigits.enabled = false;
        for (int i = 0; i < emptySlot; i++)
            inventorySlots[i].enabled = false;
    }
}
