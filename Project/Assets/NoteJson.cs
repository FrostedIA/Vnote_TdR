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
    public Button createButton;
    
    public GameObject NotePrefab;
    public GameObject Thing;
    string filePath;
    public Animator Content;


    private List<sample1> checkNotes = new List<sample1>();

    private InputField[] addInputFields;

    public class ChecklistItem
    {
        public string NoteName;
        public string type; 
        public int index1;

        public ChecklistItem(string name,string type,int index)
        {
            this.NoteName = name;
            this.type = type;
            this.index1 = index;


        }




    }

    public void DELETE()
    {
        Content.SetTrigger("DELET");
    }
    public void NORMAL()
    {
        Content.SetTrigger("sfg");
    }





    private void Start()
    {
        filePath = Application.persistentDataPath + "/note.txt";
        loadJSONdata();
        
        addInputFields = addPanel.GetComponentsInChildren<InputField>();
        createButton.onClick.AddListener(delegate { CreateCheckNoteItem(addInputFields[0].text, addInputFields[1].text); }  );
      



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


    void CreateCheckNoteItem(string name, string type,int loadIndex = 0,bool loading = false)
        {
            GameObject item = Instantiate(NotePrefab); 

            item.transform.SetParent(content);
        item.transform.localScale = new Vector3(1, 1, 1);
       sample1 itemObject = item.GetComponent<sample1>();
     
      int index = loadIndex;
        if (!loading)
            index = checkNotes.Count;
            itemObject.SetObjecInfo(name, type, index);
            checkNotes.Add(itemObject);
        sample1 temp = itemObject;
       
        
        itemObject.GetComponent<Button>().onClick.AddListener(delegate { CheckItem(temp); }) ;
      if (!loading)
        {
          SaveJSONdata();
        SwitchMode(0);    
    
        }
      
    
    }
     

    void CheckItem(sample1 item)
    {
        Debug.Log("clar");
        checkNotes.Remove(item);
        SaveJSONdata();
        Destroy(item.gameObject);
    }







    void SaveJSONdata()
    {
        string content = "";
        for(int i = 0;  i < checkNotes.Count; i++)
        {
            ChecklistItem temp = new ChecklistItem(checkNotes[i].NoteName,checkNotes[i].type,checkNotes[i].index1);
            content += JsonUtility.ToJson(temp) + "\n";
            Debug.Log("chi");
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
   ChecklistItem temp = JsonUtility.FromJson<ChecklistItem>(content.Trim());
                CreateCheckNoteItem(temp.NoteName, temp.type,temp.index1,true);
                }
            
            } 

        }
        else 
        { 
            Debug.Log("no fileeeeeeee");
        }
       

    }



}
