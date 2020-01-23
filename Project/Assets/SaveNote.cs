using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveNote : MonoBehaviour
{
    public string Dtext;
    public string Mtext;
    public GameObject note;
    public GameObject note2;
    public GameObject taitel;
    public GameObject bodie;
    public GameObject loader;

    void Start()
    {
       



    }
    public void REset()
    { Dtext = PlayerPrefs.GetString("Title");
        taitel.GetComponent<InputField>().text = Dtext;
        Mtext = PlayerPrefs.GetString("Note");
      bodie.GetComponent<InputField>().text = Mtext;

    }
    public void Savenote() 
    {
        Dtext = note.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title",Dtext);
        Mtext = note2.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);

        loader.SendMessage("LOAD");
    }
   
}
