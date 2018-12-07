using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Computer : MonoBehaviour {
    public Image password;
    public Image doorOpenOverride;
    public InputField passWordBox;
    public Text errorMessage;
    private LoadScene sceneLoader;
    private static string correctPassword = "JamesP_#73?";
    private void Start()
    {
        sceneLoader = GetComponent<LoadScene>();
    }
    public void Update()
    {
        if(password.enabled)
        {
            Button[] tempButtons = password.GetComponents<Button>();
            for(int i = 0; i < tempButtons.Length; i++)
            {
                tempButtons[i].enabled = true;
            }
            tempButtons = doorOpenOverride.GetComponents<Button>();
            for (int i = 0; i < tempButtons.Length; i++)
            {
                tempButtons[i].enabled = false;
            }
        }
        else if(doorOpenOverride.enabled)
        {
            Button[] tempButtons = doorOpenOverride.GetComponents<Button>();
            for (int i = 0; i < tempButtons.Length; i++)
            {
                tempButtons[i].enabled = true;
            }
            tempButtons = password.GetComponents<Button>();
            for (int i = 0; i < tempButtons.Length; i++)
            {
                tempButtons[i].enabled = false;
            }
        }
    }
    public void callButton(int val)
    {
        switch(val)
        {
            case 0://Submit
                //Check if passwords match. If they do, load override image. If they dont, show error that password do not match
                if(passWordBox.text == correctPassword)
                {
                    StartCoroutine(ShowMessage("Success: Permission Granted. Loading...", 2));
                    password.enabled = false;
                    passWordBox.enabled = false;
                    doorOpenOverride.enabled = true;
                }
                else
                {
                    StartCoroutine(ShowMessage("Error: Passwords Do Not Match", 2));
                }
                break;
            case 1://Cancel
                //Disable all images, set time scale back to 1. 
                password.enabled = false;
                doorOpenOverride.enabled = false;
                passWordBox.enabled = false;
                errorMessage.enabled = false;
                Time.timeScale = 1;
                break;
            case 2://Override Lock
                //Unlock door, pop up message letting user know it is unlocked, then disable all images, set time scale back to 1.
                StartCoroutine(ShowMessage("Success: Door Lock Override", 2));
                GameData.ExitOpen = true;
                callButton(1);
                break;
            case 3://Restart
                //Reload the scene. 
                sceneLoader.LoadSceneByIndex(3);
                break;
            default://Main Menu
                //Load the main menu. 
                sceneLoader.LoadSceneByIndex(0);
                break;
        }
    }
    IEnumerator ShowMessage(string message, float delay)
    {
        errorMessage.text = message;
        errorMessage.enabled = true;
        yield return new WaitForSeconds(delay);
        errorMessage.enabled = false;
    }
}
