using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clock : MonoBehaviour
{  
    public Text textClock;
    private float time;
    private DateTime oldTime;
    //Testing
    void Start (){ 
        time = 0;
   }
    void Update (){
        time = time + Time.deltaTime;
        TimeSpan currTime = TimeSpan.FromSeconds(time);
        textClock.text = currTime.ToString(@"ss\:ff");
   }
   public float tm() {
        return time;
   }
}

