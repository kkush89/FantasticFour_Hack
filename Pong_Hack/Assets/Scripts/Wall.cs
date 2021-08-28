using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall : MonoBehaviour
{

    private const int VECTOR_COUNT = 5;
    private int vectorIndex = 0;
    private Vector3[] positionChanges;
    private Vector3 prevMousePosition;
    private float[] prevTimes;
    private bool curDown = false;
    private bool prevDown = false;

    void Start()
    {
        prevMousePosition = Vector3.zero;
        positionChanges = new Vector3[VECTOR_COUNT];
        prevTimes = new float[VECTOR_COUNT];
        for (int i = 0; i < VECTOR_COUNT; i++)
        {
            positionChanges[i] = Vector3.zero;
            prevTimes[i] = 0;
        }
    }


    public Text objectSpeed;
    public Text maxSpeedDisp;
    public int OldSpeed = 0;
    public int maxSpeed;

    void Update()
    {

        Vector3 totalDistance = Vector3.zero;
        Vector3 velocity;

       

        if (curDown)
        {
            // if still down just follow the mouse (finger)
            Vector3 amountMoved = Camera.main.ScreenToWorldPoint(positionChanges[(vectorIndex - 1 + VECTOR_COUNT) % VECTOR_COUNT]) - Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            transform.position = transform.position + amountMoved;
        }
        else if (prevDown)
        {
            // just came up so calculate and set velocity
            float totalTime = 0;
           
            for (int i = 0; i < VECTOR_COUNT; i++)
            {
                totalTime += prevTimes[i];
                totalDistance += positionChanges[i];
            }
            velocity = totalDistance / totalTime;

            

            velocity = Camera.main.ScreenToWorldPoint(velocity) - Camera.main.ScreenToWorldPoint(Vector3.zero);
            GetComponent<Rigidbody2D>().velocity = velocity;

            //keeep personal best
             if (OldSpeed <= (int)velocity.magnitude)
               {
                maxSpeed = (int)velocity.magnitude;
                OldSpeed = (int)velocity.magnitude;
               }

            //displaying speed
            /*private Text objectSpeed;
            this.objectSpeed.text = _playerScore.ToString();*/

            //test displaying speed
            this.objectSpeed.text = ((int)velocity.magnitude).ToString();
            this.maxSpeedDisp.text = (maxSpeed).ToString();
    
            Debug.Log(velocity.magnitude);
        }

        

        positionChanges[vectorIndex] = Input.mousePosition - prevMousePosition;
        prevTimes[vectorIndex] = Time.deltaTime;
        vectorIndex = (vectorIndex + 1) % VECTOR_COUNT;

        

        prevDown = curDown;
        prevMousePosition = Input.mousePosition;

        /*
        if (!curDown) {
            Vector2 temp = rigidbody2D.velocity;
            if((transform.position.y > Camera.main.orthographicSize && rigidbody2D.velocity.y > 0) ||
                (transform.position.y < -Camera.main.orthographicSize && rigidbody2D.velocity.y < 0))
                temp.y *= -1;
            if((transform.position.x > Camera.main.orthographicSize * Camera.main.aspect && rigidbody2D.velocity.x > 0) ||
               (transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect && rigidbody2D.velocity.x < 0))
                temp.x *= -1;

            rigidbody2D.velocity = temp;
        }
        */
    }



    void OnMouseDown()
    {
        print("down");
        curDown = true;
        
    }

    void OnMouseUp()
    {
        print("up");
        curDown = false;
    }
}


