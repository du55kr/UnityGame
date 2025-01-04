using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Numpad : MonoBehaviour
{

    public Text numberText;
    public RulerManager rulerManager;
    public string numberInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void WriteNumber(int n)
    {
        numberInput = numberInput + n.ToString();
        int a = int.Parse(numberInput);
        rulerManager.RulerTextInput(a);
    }

    public void WriteEnter()
    {
        if(numberInput != "")
        {
            int a = int.Parse(numberInput);
            rulerManager.RulerResultInput(a);
        }
       
        numberInput = "";

    }
    public void Erase()
    {
        if (numberInput.Length > 0)
        {
            numberInput = numberInput.Substring(0, numberInput.Length - 1);
            if (numberInput.Length > 0)
            {
                int a = int.Parse(numberInput);
                rulerManager.RulerTextInput(a);
            }
            else
            {
                rulerManager.RulerTextInput(0);
            }
        }
    }
}
