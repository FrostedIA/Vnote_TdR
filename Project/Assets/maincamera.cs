using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincamera : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform go;
    void Start()
    {

    }

    // Update is called once per frame
   

       public void Moute()
        {
            go.Translate(Vector3.right * 200);


        }
    public void Moute2()
    {
        go.Translate(Vector3.left * 200);


    }
}
