using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteGenerator : MonoBehaviour
{
   
    public string Dtext;
    public string Mtext;
    public GameObject note;
    public GameObject note2;
    Canvas itself;
    public GameObject nota;
    private bool can;
    void Start()
    {
        itself = GetComponent<Canvas>();
        can = true;
    }
    public void Savenote()
    {
        Dtext = note.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = note2.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
       itself.enabled = false;
        if (can == true)
        {
            GameObject one = Instantiate(nota, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
          
        }
     
    }
public void Descartar()
    {
        itself.enabled = false;

    }
    public void open()
    {
        itself.enabled = true;
        can = false;






    }

















}
