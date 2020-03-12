using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckNote : MonoBehaviour
{   public GameObject NotePanel;
    public GameObject ru;
    public GameObject ru2;
    public string NoteName;
    public string type;
    public int index;
    private Text itemtext;
   
    public Text title;
        public Text body;
    public string Dtext;
    public string Mtext;
    private bool can;
    private bool fcan;



    private void Start()
    {
      
        itemtext = GetComponentInChildren<Text>();
         itemtext.text = NoteName;
        
        ru.GetComponent<InputField>().text = itemtext.text;
       ru2.GetComponent<InputField>().text = type;

        NotePanel.SetActive(false);
        can = false;
        fcan = false;
       
    }





    public void openPanel()
    
    {if (fcan == false) 
        {
           
            FindClosestEnemy2();
        NotePanel.SetActive(true);
       
        Dtext = title.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = body.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);

        Dtext = NoteName;
            Mtext = type;

          
            
            fcan = true;
        }
        if(fcan ==true)
        {
            FindClosestEnemy2();
            NotePanel.SetActive(true);

            Dtext = title.GetComponent<Text>().text;
            PlayerPrefs.SetString("Title", Dtext);
            Mtext = body.GetComponent<Text>().text;
            PlayerPrefs.SetString("Note", Mtext);

           
        }




    }
    public void Savenote()
    {
        can = true;
        FindClosestEnemy2();
        Dtext =title.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = body.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
         
        NotePanel.SetActive(false);
       
        Debug.Log ("seeee");
        NoteName = Dtext;
        type =Mtext;




    }
    void Update()
    {
      
    }

    



    public void SetObjecInfo(string name,string type,int index) 
    {
        this.NoteName = name;
        this.type = type;
        this.index = index;




    }
    public void FindClosestEnemy2()
    {
        float distanceToClosestEnemy = 20000;
       NoteJson closestEnemy = null;
        NoteJson[] allEnemies = GameObject.FindObjectsOfType<NoteJson>();

        foreach (NoteJson currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
              
                if(can== false) 
                {
                  closestEnemy.SendMessage("Hide");
                  
                }
                if (can == true)
                {
                    closestEnemy.SendMessage("Show");
                    can = false;
                }



            }

        }

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);






    }

}
