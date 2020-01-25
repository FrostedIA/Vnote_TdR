using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adder : MonoBehaviour
{
    public GameObject REset, REset2;
    bool active;
    public Canvas panelescritura,panelescritura2;

    void Start()
    {
        
        panelescritura.enabled = false;
        panelescritura2.enabled = false;
    }



    public void Discard()
    {
        panelescritura.enabled = false;
        panelescritura2.enabled = false;

    }
    public void Add()
    {
        panelescritura.enabled = true;
        REset.SendMessage("REset");
      
    }
    public void Add2()
    {
        panelescritura2.enabled = true;
       
        REset2.SendMessage("REset2");
    }
}
