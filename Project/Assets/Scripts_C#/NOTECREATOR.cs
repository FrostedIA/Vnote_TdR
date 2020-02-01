using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NOTECREATOR : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Panel;
    public GameObject ell;
    public int Ap;
    private int Hg = 1;
    
    public void Plus()
    {


        GameObject one = Instantiate(Panel, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
 
  aixo(Hg);


    }

    public void aixo(int Hg)
    {
        Ap += Hg;
        if (Ap > 1)
        {
            ell.SendMessage("fes");

        }
    }















}
