using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MorguePuzzle : MonoBehaviour {

    bool opened = true;
    public Inventory inventoryItem;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public Animation leftDA;
    public Animation rightDA;

    public Text screenText;
    public Image textBox;

    private void OnTriggerEnter(Collider other)
    {
        if (opened)
        {
            closeDoors();
            opened = false;
        }
    }
    public void openDoors()
    {
        if (inventoryItem.itemExists("morgueKey"))
        {
            leftDA.Play("LeftDoorC");
            rightDA.Play("RightDoorC");
            StartCoroutine(ShowMessage("Got It!", 2));
        }
        else
        {
            StartCoroutine(ShowMessage("I Have to Play His Games To Leave..", 2));
        }
    }
    public void closeDoors()
    {
        leftDA.Play("LeftDoorO");
        rightDA.Play("RightDoorO");
        StartCoroutine(ShowMessage("Shit, The door Locked Behind Me...", 2));
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        screenText.text = message;
        screenText.enabled = true;
        textBox.enabled = true;
        yield return new WaitForSeconds(delay);
        screenText.enabled = false;
        textBox.enabled = false;
    }
}
