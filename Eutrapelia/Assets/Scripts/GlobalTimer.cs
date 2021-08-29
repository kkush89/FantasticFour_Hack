using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GlobalTimer : MonoBehaviour
{
    // Define variables for timer
    public bool TimerActive = false;
    float CurrentTime;
    string RoundedTime;
    public Text CurrentTimeText;
    
    // Start is called before the first frame update
    void Start()
    {
        // initialise timer to 0
        CurrentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Add time only when timer active
        if (TimerActive == true){
            CurrentTime += Time.deltaTime;
        }

        // Display time (code from https://www.youtube.com/watch?v=HLz_k6DSQvU)
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        RoundedTime = time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        CurrentTimeText.text = "Time: " + RoundedTime + "s";
    }

    // Start timer when called
    public void StartTimer(){
        TimerActive = true;
    }

    // Stop timer when called
    public void StopTimer(){
        TimerActive = false; 
    }
}
