using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSaver : MonoBehaviour
{
    public string Dtext;
    public GameObject theText1;


    // Start is called before the first frame update


    // Update is called once per frame
    public void LOAD()
    {
       
Dtext = PlayerPrefs.GetString("Title");
       
 theText1.GetComponent<InputField>().text = Dtext;
    }
   






}
