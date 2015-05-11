using UnityEngine;
using System.Collections;

public class RemoveCollider : MonoBehaviour
{
    //Remove the colliders of the pipes when the bird is dead so that the bird can slide off the screen.
    void Update()
    {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        if(bird.isDead)
        {
            GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
