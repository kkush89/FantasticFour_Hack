using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // Call from GlobalTimer.cs and OnOffSwitch.cs
    GlobalTimer gt;
    OnOffSwitch OOS;

    // Called before the first frame update
    void Start(){
        // Define object types
        gt = GameObject.FindGameObjectWithTag("TimeTag").GetComponent<GlobalTimer>();
        OOS = GameObject.FindGameObjectWithTag("SwitchTag").GetComponent<OnOffSwitch>();
    }

    // Resets the score counter and timer, while keeping high score the same
    public void ResetGame(){
        gt.Start();
        OOS.Start();
    }
}
