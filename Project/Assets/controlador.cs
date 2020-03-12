using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador : MonoBehaviour
{
    public Animator anim;
  public void fes() 
    
    {
        anim.SetTrigger("Baixa");
    
    }
    public void reo()

    {
        anim.SetTrigger("Puja");

    }
   

    }
