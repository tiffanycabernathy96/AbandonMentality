using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadPuzzle : MonoBehaviour {
    public Puzzle keypadPuzzle; 
    public Button b_1,b_2,b_3,b_4,b_5,b_6,b_7,b_8,b_9,b_0,b_pound,b_X, b_back;
    public Image keypadImg, backImg;
    public OpenDoor door;
    public Text hexCodeText;
    List<int> inputtedNumbers = new List<int>();
    public Material m_1, m_2, m_3, m_4, m_5, m_6, m_7, m_8, m_9, m_0, m_pound, m_X, m_valid, m_invalid, m_norm;
    public Light red, green;
    HexCodeGen generator;
    List<int> lockCode = new List<int>();
    // Use this for initialization
    void Awake() {
        generator = GetComponent<HexCodeGen>();
        generator.GenerateCode();
        lockCode = generator.GetLockCode();
        keypadImg.material = m_norm;
        List<string> hexCode = generator.GetHexDigits();
        hexCodeText.text = hexCode[0].ToString() + "\n" + hexCode[1].ToString() + "\n" + hexCode[2].ToString() + "\n" + hexCode[3].ToString() + "\n" + hexCode[4].ToString();
    }
   
    public void ButtonPressed(int buttonNum)
    {
        if (keypadImg.enabled == true && Time.timeScale == 0)
        {
            switch (buttonNum)
            {
                case 0:
                    keypadImg.material = m_0;
                    inputtedNumbers.Add(0);
                    break;
                case 1:
                    keypadImg.material = m_1;
                    inputtedNumbers.Add(1);
                    break;
                case 2:
                    keypadImg.material = m_2;
                    inputtedNumbers.Add(2);
                    break;
                case 3:
                    keypadImg.material = m_3;
                    inputtedNumbers.Add(3);
                    break;
                case 4:
                    keypadImg.material = m_4;
                    inputtedNumbers.Add(4);
                    break;
                case 5:
                    keypadImg.material = m_5;
                    inputtedNumbers.Add(5);
                    break;
                case 6:
                    keypadImg.material = m_6;
                    inputtedNumbers.Add(6);
                    break;
                case 7:
                    keypadImg.material = m_7;
                    inputtedNumbers.Add(7);
                    break;
                case 8:
                    keypadImg.material = m_8;
                    inputtedNumbers.Add(8);
                    break;
                case 9:
                    keypadImg.material = m_9;
                    inputtedNumbers.Add(9);
                    break;
                case 10: //Pound
                    keypadImg.material = m_pound;
                    if (inputtedNumbers.Count == 5 && isValid())
                    {
                        keypadPuzzle.puzzleCompleted = true;
                        keypadImg.material = m_valid;
                        door.openDoor();
                        red.enabled = false;
                        green.enabled = true;
                    }
                    else
                    {
                        keypadImg.material = m_invalid;
                        inputtedNumbers.Clear();
                    }
                    break;
                case 11: //X
                    keypadImg.material = m_X;
                    inputtedNumbers.Clear();
                    break;
                case 12: //Back
                    inputtedNumbers.Clear();
                    keypadImg.enabled = false;
                    backImg.enabled = false;
                    Time.timeScale = 1;
                    break;
            }
        }
        else
        {
            keypadImg.material = m_norm;
        }
    }
    bool isValid()
    {
        bool valid = true;
        for(int i = 0; i < 5; i++)
        {
            if (lockCode[i] != inputtedNumbers[i])
                valid = false;
        }
        return valid;
    }
}
