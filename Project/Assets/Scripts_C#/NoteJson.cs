using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NoteJson : MonoBehaviour
{
    public GameObject theText1;
    public GameObject theText;
    
    public Transform content;
    
    public GameObject addPanel;
    public GameObject notePanel; public int loker;

    public int serin;
    
    public Button createButton;
    
    public GameObject NotePrefab;
    public GameObject Thing;

    public bool existeix;
    
    public Animator Content;
    public Animator DUAL;

    private List<sample1> checkNotes = new List<sample1>();

    private InputField[] addInputFields;

    public Text NoteTitle;
    string filePath;

    public int open;


    public string taitel;
    public string boday;

    public int switcher;

    public void DELETE()
    {
      
        DUAL.SetTrigger("1");
        Content.SetTrigger("DELET");
    }
    public void NORMAL()
    {
        
        DUAL.SetTrigger("2");
        Content.SetTrigger("sfg");
    }

    public void None()
    {

        SwitchMode(0);
    }



    private void Start()
    {
        
       
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("panel", 0);

        filePath = Application.persistentDataPath +"/note.txt";

        addInputFields = addPanel.GetComponentsInChildren<InputField>();
        createButton.onClick.AddListener(delegate { CreateCheckNoteItem(addInputFields[0].text, addInputFields[1].text,serin); }  );
        loadJSONdata();



    }
    public class Notelist
    {
        public string NoteName;
        public string type;
        public int index1;

        public Notelist(string name, string type, int serin)
        {
            this.NoteName = name;
            this.type = type;
            this.index1 = serin;


        }




    }
    void SaveJSONdata()
    {
        string content = "";
        for (int i = 0; i < checkNotes.Count; i++)
        {
            Notelist temp = new Notelist(checkNotes[i].NoteName, checkNotes[i].type, checkNotes[i].index1);
             content += JsonUtility.ToJson(temp) + "\n";
            Debug.Log("si");
        }
        File.WriteAllText(filePath, content);


    }
    
     void loadJSONdata()
    {
        if (File.Exists(filePath))
        {
            string contents = File.ReadAllText(filePath);
            string[] splitContents = contents.Split('\n');
           
                foreach (string content in splitContents)
                {
                    if (content.Trim() != "")
                    {
                        Notelist temp = JsonUtility.FromJson<Notelist>(content.Trim());

                        CreateCheckNoteItem(temp.NoteName, temp.type, temp.index1);

                    }



                    Debug.Log("g");
                }
            
            

        }
        else
        {
            Debug.Log("no fileeeeeeee");
        }
}

    
    private void Update()
    {
        NoteTitle.text = PlayerPrefs.GetString("titol");
        loker = PlayerPrefs.GetInt("panel");
        serin = PlayerPrefs.GetInt("indes");
       
        taitel = PlayerPrefs.GetString("Title");
        boday = PlayerPrefs.GetString("Note");


        switcher = PlayerPrefs.GetInt("chng");

        if (loker == 1)
        {
            notePanel.SetActive(true);
           
        }
        if (loker == 0)
        {
            notePanel.SetActive(false);
        }
        if (switcher == 1)
        {
            ReCreate();
            PlayerPrefs.SetInt("chng", 0);
        }
        if (switcher == 0)
        {
            
        }


    }

    public void ReCreate()
    {

        CreateCheckNoteItem(taitel,boday,serin);


    }
    public void ClosePanel()
    {
        PlayerPrefs.SetInt("panel", 0);




    }


    public  void SwitchMode(int mode)
    {
        switch (mode)
        {//interactuar
            case 0:
                addPanel.SetActive(false);
                break;
                //escriure
            case 1:
                addPanel.SetActive(true);
                theText1.GetComponent<InputField>().text = "";
                theText.GetComponent<InputField>().text = "";
                break;
        }

       
    }

    public void Hide()
    {
        Thing.SetActive(false);
      
    }
    public void Show()
    {
        Thing.SetActive(true);
    
    }


    void CreateCheckNoteItem(string name, string type,int index1)
        {
        GameObject item = Instantiate(NotePrefab);

        item.transform.SetParent(content);
        item.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);

        item.transform.localScale = new Vector3(1, 1, 1);

        sample1 itemObject = item.GetComponent<sample1>();
        

        itemObject.SetObjecInfo(name, type, index1);
        checkNotes.Add(itemObject);
        sample1 temp = itemObject;

        itemObject.Eliminador.onClick.AddListener(delegate { CheckItem(temp); });
        itemObject.Eliminador2.onClick.AddListener(delegate { CheckItem(temp); });

        SaveJSONdata();
           
        SwitchMode(0);
       
    }

    public void CheckItem(sample1 item)
    {
        Debug.Log("clar");
        checkNotes.Remove(item);
        SaveJSONdata();
        Destroy(item.gameObject);
        
      

    }


}







