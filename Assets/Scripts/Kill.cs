using UnityEngine;
using System.Collections;

public class Kill : MonoBehaviour {
    //We select the pipes and floors prefabs.
    public GameObject floor;
    public GameObject pipes;
    /////////////////////////////////////////

    //We start invoking the DestroyPipes and DestroyFloor functions over 5 seconds with an initial 5 second wait time.
    void Start()
    {
        InvokeRepeating("DestroyPipes", 5, 5);
        InvokeRepeating("DestroyFloor", 5, 5);
        
    }

    void DestroyFloor()
    {
        if (floor != null)
        {
            Destroy(floor);
        }
    }


    void DestroyPipes()
    {
        GameObject go = GameObject.Find("Burd");
        Control dead = go.GetComponent<Control>();
        //While the bird is NOT dead we delete the pipes, if it's dead we stop deleting them, as it looks fancier (we stop generating them aswell)
        if (pipes != null && !dead.isDead)
        {
            Destroy(pipes);
        }
    }
}
