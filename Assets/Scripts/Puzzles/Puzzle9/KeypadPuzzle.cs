using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeypadPuzzle : MonoBehaviour {

    public Button b_1,b_2,b_3,b_4,b_5,b_6,b_7,b_8,b_9,b_0,b_pound,b_X, b_back;
    public Image keypadImg, backImg;
    public OpenDoor door;
    List<int> inputtedNumbers = new List<int>();
    public Material m_1, m_2, m_3, m_4, m_5, m_6, m_7, m_8, m_9, m_0, m_pound, m_X, m_valid, m_invalid, m_norm;

    // Use this for initialization
    void Start () {

        /*Button num0 = b_0.GetComponent<Button>();
        Button num1 = b_1.GetComponent<Button>();
        Button num2 = b_2.GetComponent<Button>();
        Button num3 = b_3.GetComponent<Button>();
        Button num4 = b_4.GetComponent<Button>();
        Button num5 = b_5.GetComponent<Button>();
        Button num6 = b_6.GetComponent<Button>();
        Button num7 = b_7.GetComponent<Button>();
        Button num8 = b_8.GetComponent<Button>();
        Button num9 = b_9.GetComponent<Button>();
        Button pound = b_pound.GetComponent<Button>();
        Button numX = b_X.GetComponent<Button>();
        Button back = b_back.GetComponent<Button>();

        num0.onClick.AddListener(delegate { ButtonPressed(0); });
        num1.onClick.AddListener(delegate { ButtonPressed(1); });
        num2.onClick.AddListener(delegate { ButtonPressed(2); });
        num3.onClick.AddListener(delegate { ButtonPressed(3); });
        num4.onClick.AddListener(delegate { ButtonPressed(4); });
        num5.onClick.AddListener(delegate { ButtonPressed(5); });
        num6.onClick.AddListener(delegate { ButtonPressed(6); });
        num7.onClick.AddListener(delegate { ButtonPressed(7); });
        num8.onClick.AddListener(delegate { ButtonPressed(8); });
        num9.onClick.AddListener(delegate { ButtonPressed(9); });
        pound.onClick.AddListener(delegate { ButtonPressed(10); });
        numX.onClick.AddListener(delegate { ButtonPressed(11); });
        back.onClick.AddListener(delegate { ButtonPressed(12); });

        keypadImg.material = m_norm;*/
    }
    
    void ButtonPressed(int buttonNum)
    {
        /*if (keypadImg.enabled == true)
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
                    if (inputtedNumbers.Count == 5)
                    {
                        keypadImg.material = m_valid;
                        door.openDoor();
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
        }*/
    }
}
