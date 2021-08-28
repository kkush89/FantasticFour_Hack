using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBubbleClick : MonoBehaviour
{
    // Define bubble count, and object to call functions from Globaltimer.cs
    int BubbleCount;
    GlobalTimer gt;
    public GameObject Button;

    void Start()
    {
        // Initialise bubble count to 21 (max no. of buttons)
        BubbleCount = 21;
    }

    // Update is called once per frame
    void Update()
    {
        if(BubbleCount == 0){
            gt = GameObject.FindGameObjectWithTag("TimeTag").GetComponent<GlobalTimer>();
            // Stop timer and activate reset button when all bubbles popped
            gt.StopTimer();
            Button.SetActive(true);
        }
    }
    
    // Decrease bubbles left by 1
    public void BubblePopped(){
        BubbleCount -= 1;
    }

}
