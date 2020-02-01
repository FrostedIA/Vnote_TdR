using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteGenerator : MonoBehaviour
{
    public Transform clic;
    public string Dtext;
    public string Mtext;
    public GameObject note;
    public GameObject note2;
   public GameObject itself;


    private bool StartResearch;
    
    public bool able;

   



    void Start()
    {

       
      

    }
   

    public void Savenote()
    {
        
        Dtext = note.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = note2.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
       itself.SetActive(false);
        able = true;
     StartResearch = true;
      

     
     
    }



    public void Baixa()

    {
        clic.Translate(Vector3.down * 200);


    }


    public void Descartar()
    {
        itself.SetActive(false);

    }
    public void open()
    {
        itself.SetActive(true);
       
        
    }
    void Update()
    {
 if (StartResearch == true)
        { 
         FindClosestEnemy2();
        }
    } 
        
     void OnCollisionEnter2D(Collision2D col)
        {
        if (col.gameObject.tag == "Daon")
        {
            Baixa();
        }
    }
       
        
       
    

    void FindClosestEnemy2()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
       NoteSaver1 closestEnemy = null;
        NoteSaver1[] allEnemies = GameObject.FindObjectsOfType<NoteSaver1>();

        foreach (NoteSaver1 currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                if (able == true)
                {
                    closestEnemy.SendMessage("Set");
                    able = false;

                }

            }
        }

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);

        




    }
















}
