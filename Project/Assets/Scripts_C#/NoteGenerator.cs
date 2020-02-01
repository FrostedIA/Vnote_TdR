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
    public GameObject nota;
    private bool can;
    private bool Search;
    public Collider2D colir;
    public bool able;

   



    void Start()
    {

        colir.isTrigger = false;

        can = true;
        Search = false;
    }
   

    public void Savenote()
    {
        
        Dtext = note.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = note2.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
       itself.SetActive(false);
        able = true;
        colir.isTrigger = true;


        if (can == true)
        { 
            GameObject one = Instantiate(nota, new Vector3(0, 417, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note2").transform, false);
            Search = true; can = false;
        }
     
    }



    public void Baixa()

    {
        clic.Translate(Vector3.down * 200);


    }


    public void Descartar()
    {
        itself.SetActive(false);
        Search = false;
    }
    public void open()
    {
        itself.SetActive(true);
        
        
    }
    void Update()
    {
 if (Search == true)
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
        float distanceToClosestEnemy = 400;
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
