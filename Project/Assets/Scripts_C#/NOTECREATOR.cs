using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTECREATOR : MonoBehaviour
{
    // Start is called before the first frame update
    
   
    public GameObject Panel;
    public Transform place;
    public int Taps = 4;
    private int NumOfTaps = 1;
    
    public void Plus()
    {


        GameObject one = Instantiate(Panel, place.position, Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
                   

        touches(NumOfTaps);
    }

   



    public void touches(int NumOfTaps)
    {
        Taps -= NumOfTaps;
       place.transform.position = new Vector3(0,Taps, 0);



    }











}
