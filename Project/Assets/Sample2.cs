using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sample2 : MonoBehaviour
{
    public string NoteName;
    public string type;
    public int index;
    public Text title;
    public Text body;
    public GameObject ru;
    public GameObject ru2;
    public string Dtext;
    public string Mtext;
    public Button createButton;
    private List<sample1> checkNotes = new List<sample1>();
    public GameObject NotePrefab;
    private InputField[] addInputFields;
    public GameObject addPanel;
    public GameObject Itself;
    void Start()
    {
        ru.GetComponent<InputField>().text =NoteName;
        ru2.GetComponent<InputField>().text = type;
        addInputFields = addPanel.GetComponentsInChildren<InputField>();
        createButton.onClick.AddListener(delegate { CreateCheckNoteItem(addInputFields[0].text, addInputFields[1].text); });

    }
    public void Savenote()
    {
        Dtext = title.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = body.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
        NoteName = Dtext;
        type = Mtext;

    }

    void CreateCheckNoteItem(string name, string type)
    {
        GameObject item = Instantiate(NotePrefab);

        item.transform.SetParent(GameObject.FindGameObjectWithTag("Content").transform, false);
        item.transform.localScale = new Vector3(1, 1, 1);
        sample1 itemObject = item.GetComponent<sample1>();
        int index = 0;
        if (checkNotes.Count > 0)
            index = checkNotes.Count - 1;


        itemObject.SetObjecInfo(name, type, index);
        checkNotes.Add(itemObject);
        sample1 temp = itemObject;
        Destroy(Itself);
    }









        public void SetObjecInfo(string name, string type, int index)
    {
        this.NoteName = name;
        this.type = type;
        this.index = index;




    }
}
