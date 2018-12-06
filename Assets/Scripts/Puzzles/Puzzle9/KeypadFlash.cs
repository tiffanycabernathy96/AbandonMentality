using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KeypadFlash : MonoBehaviour {

    public float totalSeconds;     // The total of seconds the flash wil last
    public float maxIntensity;     // The maximum intensity the flash will reach
    private Light myLight;        // Your light
    public IEnumerator coroutine;
    public Puzzle keyPadPuzzle;
    public Text screenText;
    public Image textBox;
    void Start()
    {
        myLight = GetComponent<Light>();
        
    }
    private void FixedUpdate()
    {
        if(GameData.DayRoomPuzzle)
        {
            GameData.DayRoomPuzzle = false;
            keyPadPuzzle.puzzleActivated = true;
            myLight.enabled = true;
            coroutine = flashNow();
            StartCoroutine(ShowMessage("Hear that? Sounds Like a Generator was Powered on!", 3));
            StartCoroutine(coroutine);
        }
    }
    public IEnumerator flashNow()
    {
        while(true)
        {
            float waitTime = totalSeconds / 2;
            // Get half of the seconds (One half to get brighter and one to get darker)
            while (myLight.intensity < maxIntensity)
            {
                myLight.intensity += Time.deltaTime / waitTime;        // Increase intensity
                yield return null;
            }
            while (myLight.intensity > 0)
            {
                myLight.intensity -= Time.deltaTime / waitTime;        //Decrease intensity
                yield return null;
            }
            
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
        GameData.DayRoomPuzzle = false;
    }
}
