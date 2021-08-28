using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public new Rigidbody2D rigidbody { get; private set; }

    public Text cornerContact;
    public Text cornerContactPB;

    
    

    private void Awake()
    {
        this.rigidbody = GetComponent<Rigidbody2D>();
    }


    private int _playerScore = 0;

    private int _personalBest = 0;

    //public float swipeSpeed = 0;

    /*public void CubeSwiped()
    {

        Vector3 velocity;

        //velocity = Camera.main.ScreenToWorldPoint(velocity) - Camera.main.ScreenToWorldPoint(Vector3.zero);
        velocity = ball.Rigidbody2D.velocity;
        swipeSpeed = velocity.magnitude;

        Debug.Log(swipeSpeed);
    }*/

    public void PlayerScores()
    {
        _playerScore++;
       

        this.cornerContact.text = _playerScore.ToString();

    }

    public void NewPersonalBest()
    {
        this.cornerContactPB.text = cornerContactPB.ToString();
    }
}
