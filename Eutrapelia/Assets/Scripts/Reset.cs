using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset : MonoBehaviour
{
    // reloads current scene (from https://answers.unity.com/questions/1261937/creating-a-restart-button.html)
    public void ResetGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
