using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class GlobalTimer : MonoBehaviour
{
    // Variables for stopwatch
    public bool TimerActive = false;
    float CurrentTime;
    string RoundedTime;
    public Text CurrentTimeText;
    // Public, changeable in Unity 
    public float StartMinutes;
    
    // Start is called before the first frame update
    public void Start()
    {
        // Changes time to seconds
        CurrentTime = 60*StartMinutes;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease time while timer is active
        if (TimerActive == true){
            CurrentTime -= Time.deltaTime;

            // Stop timer when 0 is hit, fixing at 0 to prevent negative values
            if (CurrentTime <= 0){
                TimerActive = false;
                CurrentTime = 0;
            }
        }
        // Converts to new object type, while rounding to 3dp (from https://www.youtube.com/watch?v=HLz_k6DSQvU)
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
        RoundedTime = time.Seconds.ToString() + "." + time.Milliseconds.ToString();
        // Print current time to text box
        CurrentTimeText.text = "Time: " + RoundedTime + "s";

    }
    // Activate timer when function run
    public void StartTimer(){
        TimerActive = true;
    }
}
