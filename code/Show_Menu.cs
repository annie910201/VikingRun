using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_Menu : MonoBehaviour
{
    public  Text menuText;
    public static int count = 0;
    void Start()
    {
        if (count==0)
            menuText.text = "Welcome to Viking Run";
        else
            menuText.text = "Your score : "+Show_Score.scoreGet+"\nYour money : "+Show_Money.moneyGet;
        count++;
    }

    
}
