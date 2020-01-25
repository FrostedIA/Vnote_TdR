using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSaver1 : MonoBehaviour
{
   
    public string ELTITOL;
    public string LANOTA;
    private bool able;
    
    public GameObject theText1;
    



    // Start is called before the first frame update
    void Start()
    {
        {
            
            able = true;
            notesaver1();
        }
    }

    // Update is called once per frame
    public void notesaver1()
    {
        if (able == true)
        {
            ELTITOL = PlayerPrefs.GetString("Title");
            LANOTA = PlayerPrefs.GetString("Note");

            theText1.GetComponent<InputField>().text = ELTITOL;
            able = false;
           
        }
    }
     public void open()
    {
       // GameObject.FindGameObjectWithTag("MainCanvas").SendMessage("open");
    }
   
    








    }
   
   







