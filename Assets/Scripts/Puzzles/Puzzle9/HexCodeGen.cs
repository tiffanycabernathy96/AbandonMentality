using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HexCodeGen : MonoBehaviour {
    Dictionary<int, string> hexTable = new Dictionary<int, string>
    {
        { 0, "0" }, { 1, "1" }, { 2, "2" }, { 3, "3" },
        { 4, "4" }, { 5, "5" }, { 6, "6" }, { 7, "7" },
        { 8, "8" }, { 9, "9" }, { 10, "A" }, { 11, "B" },
        { 12, "C" }, { 13, "D" }, { 14, "E" }, { 15, "F"}
    };
    List<string> hexNumbers = new List<string>();
    List<int> decimalNumbers = new List<int>();
    List<int> lockCode = new List<int>();
    private void Start()
    {
        GenerateCode();
    }
    void GenerateCode(int lockDigits = 5)
    {
        System.Random rand = new System.Random();
        for (int i = 0; i < lockDigits; i++)
        {
            int newVal = rand.Next(16, 61);
            while(decimalNumbers.Contains(newVal))
            {
                newVal = rand.Next(16, 61);
            }
            decimalNumbers.Add(newVal);
            lockCode.Add(newVal % 10);
            DecimalToHex(newVal);
        }
    }
    void DecimalToHex(int val)
    {
        string hexVal = "";
        int result=val;
        while(result > 0)
        {
            hexVal = hexTable[(result % 16)] + hexVal;
            result /= 16;
        }
        hexNumbers.Add(hexVal);
    }
    List<string> GetHexDigits()
    {
        return hexNumbers;
    }
    List<int> GetDecimalNumbers()
    {
        return decimalNumbers;
    }
    List<int> GetLockCode()
    {
        return lockCode;
    }
}
