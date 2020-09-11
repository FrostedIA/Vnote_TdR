using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class FolderCreator : MonoBehaviour
{
    public GameObject folder;
    public GameObject Fader;

    
    public int IconNumber;


    public bool unaviable;
    public bool set;

    public Text QTitle;
    public GameObject namer;

    public Animator Comp;
    public GameObject limit;

    public Transform content;
    public GameObject addPanel;
    public Button createButton;

    public GameObject NotePrefab;
  
    string filePath;


    private List<FolderStorage> checkNotes = new List<FolderStorage>();

    private InputField[] addInputFields;

    public int z;





    public void Clear()
    {

       namer.GetComponent<InputField>().text = "";
        


    }
 

    private void Update()
    {
        Debug.Log(PlayerPrefs.GetInt("s"));

       

      if (set == false)
        {

            Fader.SetActive(false);

        }

        if (set == true)
        {
            Fader.SetActive(true);


        }



    }

    public void tre()
    {
        IconNumber = 0;
    }
    public void seter()
    {
        if (unaviable == false)
        {
 
 set =! set;
          

        }
        if (unaviable == true)
        {

            limit.SetActive(true);//provisional
            

        }
       

    }


   void Start()
    {
        z = PlayerPrefs.GetInt("numserie"); 
        //PlayerPrefs.DeleteAll();
        filePath = Application.persistentDataPath + "/Quest.txt";
        loadJSONdata();
        
        addInputFields = addPanel.GetComponentsInChildren<InputField>();
        createButton.onClick.AddListener(delegate { CreateCheckNoteItem(addInputFields[0].text,IconNumber,z); });
      
        set = false;


    }
    public void numadder()
    {
        z +=1;
        PlayerPrefs.SetInt("numserie", z);

    }
    public class ChecklistItem
    {
        public string NoteName;
        public int icons;
        public int index1;

        public ChecklistItem(string name,int icon, int index)
        {
            this.NoteName = name;
            this.icons = icon;
            this.index1 = index;


        }




    }


    public void CChanger(int Number)
    {
        IconNumber = Number;
    }


   


    void CreateCheckNoteItem(string name,int icona,int index )
    {
        
        GameObject item = Instantiate(NotePrefab);

        item.transform.SetParent(content);
        item.transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0);
            
        item.transform.localScale = new Vector3(1, 1, 1);
        
       FolderStorage itemObject = item.GetComponent<FolderStorage>();

     
            
        itemObject.SetObjecInfo2(name, icona, index);
        checkNotes.Add(itemObject);
         FolderStorage temp = itemObject;

        itemObject.completer.onClick.AddListener(delegate { CheckItem(temp); });
        
      
            SaveJSONdata();
            

      

    }





    public void CheckItem(FolderStorage item)
    {
        Debug.Log("clar");
        checkNotes.Remove(item);
        SaveJSONdata();
        Destroy(item.gameObject);
       
        Comp.SetTrigger("s");

    }




    void SaveJSONdata()
    {
        string content = "";
        for (int i = 0; i < checkNotes.Count; i++)
        {
            ChecklistItem temp = new ChecklistItem(checkNotes[i].NoteName, checkNotes[i].icons, checkNotes[i].index1);
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
                    CreateCheckNoteItem(temp.NoteName,temp.icons, temp.index1);
                }
              
            }
           
        }
        else
        {
            Debug.Log("no fileeeeeeee");
        }


    }








}
