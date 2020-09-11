using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Sample2 : MonoBehaviour
{
    public string NoteName;
    public string type;
    public int index1;
    public Text title;
    public Text body;
    public GameObject ru;
    public GameObject ru2;
    public string Dtext;
    public string Mtext;
    public Button createButton;

    public string ftitle;
    public string fbody;

    public GameObject NotePrefab;
  
    public GameObject addPanel;
    public GameObject Itself;
    
    void Start()
    {
      
        ru.GetComponent<InputField>().text = NoteName;
        ru2.GetComponent<InputField>().text = type;
        ftitle = NoteName;
        fbody = type;
    }
    public void Savenote()
    {
        Dtext = title.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = body.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
        NoteName = Dtext;
        type = Mtext;


        PlayerPrefs.SetInt("chng", 1);
        Destroy(Itself);
    }

    public void Discard()
    {
        PlayerPrefs.SetString("Title", ftitle);
        PlayerPrefs.SetString("Note", fbody);

        PlayerPrefs.SetInt("chng", 1);
        Destroy(Itself);

    }








        public void SetObjecInfo(string name, string type, int index)
    {
        this.NoteName = name;
        this.type = type;
        this.index1 = index;




    }
}

