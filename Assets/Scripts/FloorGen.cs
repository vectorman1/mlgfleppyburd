using UnityEngine;
using System.Collections;

public class FloorGen : MonoBehaviour {
   
    //Initializing every floor piece with a X speed of -4
    void Start()
    {
        Vector2 velocity = new Vector2(-4, 0);
        GetComponent<Rigidbody2D>().velocity = velocity;
    }
}
