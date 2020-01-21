using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adder : MonoBehaviour
{
    bool active;
    public Canvas panelescritura;

    void Start()
    {
        
        panelescritura.enabled = false;
    }



    public void Discard()
    {
        panelescritura.enabled = false;


    }
    public void Add()
    {
        panelescritura.enabled = true;

    }
}
