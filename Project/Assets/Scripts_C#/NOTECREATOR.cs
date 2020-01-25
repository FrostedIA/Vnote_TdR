using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTECREATOR : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    public GameObject Panel;
  


    public void Plus()
    {


        GameObject one = Instantiate(Panel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);





    }












}
