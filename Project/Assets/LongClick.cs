using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LongClick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler
{
    private bool PointerDown;
    private float HoldTimer;

    public Animator anim;


    public float TimeNeed;

    public UnityEvent OnLongClick;

   public void OnPointerDown(PointerEventData eventData)
    {
        PointerDown = true;
        Debug.Log("OPD");
        


    }
   
    public void OnPointerUp(PointerEventData eventData)
    {

        Reset();


    }
    // Update is called once per frame
    void Update()
    {
        

        if(PointerDown)
        {
            HoldTimer += Time.deltaTime;

            if(HoldTimer > TimeNeed)
            {
                anim.SetTrigger("el");
                if(OnLongClick != null)
                    OnLongClick.Invoke();

                Reset();


            }





        }








    }
    public void re()
    {



        anim.SetTrigger("Return");
    }


    private void Reset()
    {
        PointerDown = false;
        HoldTimer = 0;

    }

}
