using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteSaver1 : MonoBehaviour
{
   
    public string ELTITOL;
    public string LANOTA;
    private bool able;
    private bool can;
    public GameObject theText1;
    public Transform ell;
    public Animator anim;
    



    // Start is called before the first frame update
    void Start()
    {
        
        can = false;
            able = true;
            notesaver1();
        
    }

    // Update is called once per frame
    public void notesaver1()
    {
        if (able == true)
        {
            ELTITOL = PlayerPrefs.GetString("Title");
            LANOTA = PlayerPrefs.GetString("Note");
         
            theText1.GetComponent<InputField>().text = ELTITOL;
           
            able = false;
           
        }
    }
  public void openn()
    {
        can = true;
       
    }
    public void Set()
    {
        ELTITOL = PlayerPrefs.GetString("Title");
        LANOTA = PlayerPrefs.GetString("Note");

        theText1.GetComponent<InputField>().text = ELTITOL;
       
    }

    public void Baixa()

    {
        ell.Translate(Vector3.down *230);

       
    }

    void Update()
    {
        FindClosestEnemy();
       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Daon")
        {
            Baixa();
        }
        






    }
    void FindClosestEnemy()
    {
        float distanceToClosestEnemy = 400;
       NoteGenerator closestEnemy = null;
       NoteGenerator[] allEnemies = GameObject.FindObjectsOfType<NoteGenerator>();
     
        foreach (NoteGenerator currentEnemy in allEnemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
                
             if (can == true)
                { 
                    closestEnemy.SendMessage("open");

                    can = false;
                
                }
               
            }
        }

        Debug.DrawLine(this.transform.position, closestEnemy.transform.position);
    }










}









