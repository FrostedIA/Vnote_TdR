using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTECREATOR : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject nota;
    public GameObject Panel;
    public GameObject ell;
   
    
    public void Plus()
    {


        GameObject one = Instantiate(Panel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
       
        GameObject two = Instantiate(nota, new Vector3(0, 417, 0), Quaternion.identity) as GameObject;
        two.transform.SetParent(GameObject.FindGameObjectWithTag("Note2").transform, false);
 ell.SendMessage("fes");

    }

   



   











}
