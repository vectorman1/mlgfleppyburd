using UnityEngine;
using System.Collections;

public class ObstacleRun : MonoBehaviour {

    //Speed of the pipes moving towards -4Y
    public Vector2 velocity = new Vector2(-4, 0);
    public Vector2 highVelocity = new Vector2(-16, 0);

    //How the pipe generation diferentiates from one another by Y
    public float range = 2;
    
    void Start()
    {
        //Give the pipes the speed of -4Y.
        GetComponent<Rigidbody2D>().velocity = velocity;

        //Complicated stuff I use to make the Y spawn randomized by range.
        transform.position = new Vector3(transform.position.x, transform.position.y - range * Random.value, transform.position.z);   
    }
    void Update()
    {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();

        if (!bird.isHigh)
        {
            GetComponent<Rigidbody2D>().velocity = highVelocity;
        }
        else GetComponent<Rigidbody2D>().velocity = velocity;

        if (!bird.isDead)
        {
            //Give the pipes the speed of -4Y.
            GetComponent<Rigidbody2D>().velocity = velocity;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
