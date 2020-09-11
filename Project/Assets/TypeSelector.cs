using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TypeSelector : MonoBehaviour
{
    public Image Shower;

    public Sprite[] spr;

    public int num;
    public FolderCreator fr;


   public void fre()
    {
        num = 0;
        
    }
    public void FCC()
    {


        fr.SendMessage("CChanger",num);

    }
   public void Change()
    {
       if(num < 8)
        {

            num++;

        }
        if (num > 7)
        {
            num = 0;

        }




    }

    private void Update()
    {
         Shower.sprite = spr[num];
    }







}
