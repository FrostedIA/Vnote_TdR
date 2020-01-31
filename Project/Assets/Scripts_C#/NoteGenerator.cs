using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteGenerator : MonoBehaviour
{
   
    public string Dtext;
    public string Mtext;
    public GameObject note;
    public GameObject note2;
   public GameObject itself;
    public GameObject nota;
    private bool can;
    private bool StartResearch;
    
    public bool able;
   
    void Start()
    {
        
       
        can = true;

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
        if (can == true)
        {
            GameObject one = Instantiate(nota, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note2").transform, false);
          
        }
     
    }
public void Descartar()
    {
        itself.SetActive(false);

    }
    public void open()
    {
        itself.SetActive(true);
       
        can = false;
    }
    void Update()
    {
    if (StartResearch == true)
            { 
            
            FindClosestEnemy2();

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
