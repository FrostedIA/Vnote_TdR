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
    private bool yes;






    private void Start()
    {
        yes = true;
    }
    public void Plus()
    {
        if (yes == true)
        {
            GameObject one = Instantiate(Panel, new Vector3(0, -293, 0), Quaternion.identity) as GameObject;
            one.transform.SetParent(GameObject.FindGameObjectWithTag("Note").transform, false);
            Debug.Log("si");
            aixo(Hg);
             StartCoroutine(Patata());
        }

    }

    IEnumerator Patata()
    {
        yes = false;
        yield return new WaitForSeconds(2f);
        yes = true;
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














