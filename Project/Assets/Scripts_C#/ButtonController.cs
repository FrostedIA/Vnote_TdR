﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject ByePanel;
    public GameObject theText;
    public void ClearText()
    {
        theText.GetComponent<InputField>().text = "";
       
}







}