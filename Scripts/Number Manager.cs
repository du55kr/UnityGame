using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UI;
public class NumberManager : MonoBehaviour
{
    public GameObject Name;
    public Text resultText; //정답 나타내는 숫자.
    private int num;
    public Button Number; //자기자신
    public List<GameObject> ShadowContent = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {

        Number.onClick.AddListener(ShowNum);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ShowNum()
    {
        resultText.text = num.ToString();
        num = 0;
    }
}   

