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
    Canvas itself;
    public GameObject nota;
    private bool can;
    public bool able;
    void Start()
    {
        itself = GetComponent<Canvas>();
        can = true;

    }
    public void Savenote()
    {
        Dtext = note.GetComponent<Text>().text;
        PlayerPrefs.SetString("Title", Dtext);
        Mtext = note2.GetComponent<Text>().text;
        PlayerPrefs.SetString("Note", Mtext);
       itself.enabled = false;
        able = true;
        if (can == true)
        {
            GameObject one = Instantiate(nota, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
          
        }
     
    }
public void Descartar()
    {
        itself.enabled = false;

    }
    public void open()
    {
        itself.enabled = true;
        can = false;
    }
    void Update()
    {
        FindClosestEnemy2();

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
