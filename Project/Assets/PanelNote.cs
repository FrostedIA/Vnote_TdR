using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelNote : MonoBehaviour
{
    public GameObject NotePanel;
   
   
    public Text title;
    public Text body;
    public string Dtext;
    public string Mtext;

    private void Start()
    {
       
    }
    private void Update()
    {
 Dtext =title.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = body.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
         
        NotePanel.SetActive(false);
        
        Debug.Log("seeee");
       title.text = Dtext;
       body.text =Mtext;
    }
   

   
   



}
