using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class OnOffSwitch : MonoBehaviour
{
    // Define Sprites for button changes
    public Sprite OffImage;
    public Sprite OnImage;
    public Button button;

    // Initialise Counter and high score to 0, define relevant textboxes
    int SwitchCounter;
    public GameObject CounterTextbox;
    int HighScore = 0;
    public GameObject HighScoreTextbox;

    // Define new object from GlobalTimer.cs
    public GlobalTimer gt;

    // Start is called before the first frame update
    public void Start()
    {
        // initialise counter to 0, and define gt to find variables from GlobalTimer.cs
        SwitchCounter = 0;
        gt = FindObjectOfType<GlobalTimer>();    
    }

    // Update is called once per frame
    void Update()
    {
        // Update score textbox
        CounterTextbox.GetComponent<Text>().text = "Score: " + SwitchCounter;

        if(gt.TimerActive == false){
            // Update high score
            if(SwitchCounter > HighScore){
                HighScore = SwitchCounter;
            }
            // Update high score textbox
            HighScoreTextbox.SetActive(true);
            HighScoreTextbox.GetComponent<Text>().text = "High Score: " + HighScore;
            // Disable button if timer stopped
            button.enabled = false;
        }
        else{
            //enable button if timer on
            button.enabled = true;
        }
    }

    public void ButtonPress(){
        // Update image when button pressed, only if timer is running
        if(gt.TimerActive == true){
            if (button.image.sprite == OnImage){
                button.image.sprite = OffImage;
            }
            else {
                button.image.sprite = OnImage;
            }
            //update counter
            SwitchCounter += 1;
        }
    }
}
