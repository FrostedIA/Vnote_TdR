using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
   

    private List<sample1> checkNotes = new List<sample1>();

    private InputField[] addInputFields;




    private void Start()
    {
        filePath = Application.persistentDataPath + "/note.txt";
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


    void CreateCheckNoteItem(string name, string type)
        {
            GameObject item = Instantiate(NotePrefab); 

            item.transform.SetParent(content);
        item.transform.localScale = new Vector3(1, 1, 1);
       sample1 itemObject = item.GetComponent<sample1>();
        int index = 0;
        if (checkNotes.Count > 0)
       index = checkNotes.Count - 1;


            itemObject.SetObjecInfo(name, type, index);
            checkNotes.Add(itemObject);
        sample1 temp = itemObject;
   
        SwitchMode(0);    
    
    
    }






}
