using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderStorage : MonoBehaviour
{

    public GameObject him;
    public GameObject ru;
    

    public string NoteName;
    

    public int index1;
    public int icons;

    public int num;

    public Button completer;

    public Sprite[] sprites;
    
    public Image spr;
    
    private Text itemtext;

    

    // Start is called before the first frame update
    void Start()
    {
        
        ru.GetComponent<InputField>().text = NoteName;
        itemtext = GetComponentInChildren<Text>();
        itemtext.text = NoteName;
      
        if (icons == 0)
        {
            spr.sprite = sprites[0];
        }
        if (icons == 1)
        {
            spr.sprite = sprites[1];
        }
        if (icons == 2)
        {
            spr.sprite = sprites[2];
        }
        if (icons == 3)
        {
            spr.sprite = sprites[3];
        }
        if (icons == 4)
        {
            spr.sprite = sprites[4];
        }
        if (icons == 5)
        {
            spr.sprite = sprites[5];
        }
        if (icons == 6)
        {
            spr.sprite = sprites[6];
        }
        if (icons == 7)
        {
            spr.sprite = sprites[7];
        }



    }
    

    public void setname()
    {

        PlayerPrefs.SetInt("numicon", icons);
        PlayerPrefs.SetString("titol", NoteName);
        PlayerPrefs.SetInt("panel", 1);
        PlayerPrefs.SetInt("indes", num);

    }



   

    private void Update()
    {
        num = index1;
    }
    public void SetObjecInfo2(string name,int icona, int index)
    {
        this.NoteName = name;
        this.icons = icona;
        this.index1 = index;




    }
   

}
