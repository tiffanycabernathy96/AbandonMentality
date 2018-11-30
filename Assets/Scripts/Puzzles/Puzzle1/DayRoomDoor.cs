using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayRoomDoor : MonoBehaviour {

    public bool keyFound = false;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public Text screenText;
    public Image textBox;

    Vector3 rightOpenPosition = new Vector3(1.225f, -2.989791e-08f, 0.85f);
    Quaternion rightORotation = new Quaternion(0f, 113.303f, 0f, 0);

    Vector3 leftOpenPosition = new Vector3(-1.196f, 0f, 0.882f);
    Quaternion leftORotation = new Quaternion(-180f, -111.068f, -1.525879e-05f, 0);

    private void Start()
    {
        rightORotation.w = rightDoor.transform.rotation.w;
        leftORotation.w = leftDoor.transform.rotation.w;
    }
    public void openDoors()
    {
        if(keyFound)
        {
            leftDoor.transform.position = leftOpenPosition;
            leftDoor.transform.rotation = leftORotation;
            rightDoor.transform.position = rightOpenPosition;
            rightDoor.transform.rotation = rightORotation;
        }
        else
        {
            StartCoroutine(ShowMessage("Hmm, It appears we need a key.", 2));
        }
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
