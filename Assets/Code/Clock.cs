using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{  
    public Text textClock;
    private DateTime startTime;
    //Testing
    void Start (){ 

   }
    void Update (){
        DateTime time = DateTime.Now;
        string minute = LeadingZero( time.Minute );
        string second = LeadingZero( time.Second );
        textClock.text = minute + ":" + second;
   }
   string LeadingZero (int n){
        return n.ToString().PadLeft(2, '0');
   }
}

