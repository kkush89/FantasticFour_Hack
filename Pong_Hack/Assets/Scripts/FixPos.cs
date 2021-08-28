using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPos : MonoBehaviour
{
    public void Update()
    {
          
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().position = Vector2.zero;
        
    }
    
}
