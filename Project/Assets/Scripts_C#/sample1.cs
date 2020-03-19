using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sample1 : MonoBehaviour
{
    public GameObject NotePanel;
    public GameObject Itself;
    public string NoteName;
    public string type;
    public int index1;
    private Text itemtext;
    public GameObject addPanel;

    public Button createButton;
    public Text title1;
    public Text body1;

    private InputField[] addInputFields;

    private List<Sample2> SA = new List<Sample2>();
    public GameObject ru;
    public GameObject ru2;


    private void Start()
    {
        
        ru.GetComponent<InputField>().text = NoteName;
        ru2.GetComponent<InputField>().text = type;




        itemtext = GetComponentInChildren<Text>();
        itemtext.text = NoteName;
        addInputFields = addPanel.GetComponentsInChildren<InputField>();
        createButton.onClick.AddListener(delegate { CreateCheckNoteItem(addInputFields[0].text, addInputFields[1].text); });
    


    }


 
    public void SetObjecInfo(string name, string type, int index)
    {
        this.NoteName = name;
        this.type = type;
        this.index1 = index;




    }
    void CreateCheckNoteItem(string name, string type)
    {
        GameObject item = Instantiate(NotePanel);

        item.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
        item.transform.localScale = new Vector3(1, 1, 1);
       Sample2 itemObject = item.GetComponent<Sample2>();
        int index = index1;
        if (SA.Count > 0)
            index = SA.Count - 1;


        itemObject.SetObjecInfo(name, type, index);
        SA.Add(itemObject);
       Sample2 temp = itemObject;
        Destroy(Itself);
       
    }


   
 





    

}
