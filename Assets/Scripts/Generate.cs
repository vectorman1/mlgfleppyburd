using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {
    
    //We specify the Pipes and Floor prefabs on the public gameobjet field.
    public GameObject pipes;
    public GameObject floor;
    //////////////////////////////////////////////////////////////////////

    //We specify the 1 - Initial wait before invoking the first CreateFloor/Pipes function and then the interval between invoking it again.
    public float initialWaitPipes = 1.7f;
    public float intervalPipes = 1.7f;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public float initialWaitFloor = 1f;
    public float intervalFloor = 1f;
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	//We start invoking the CreateFloor and CreatePipes functions here.
	void Start () {
        InvokeRepeating("CreateFloor", initialWaitFloor, intervalFloor);
        InvokeRepeating("CreatePipes", initialWaitPipes, intervalPipes);
	}
    void Update()
    {
        GameObject go = GameObject.Find("Burd");
        Control dead = go.GetComponent<Control>();

        //If the bird is dead, we may just cancel the generating of pipes as we don't need it, we leave the moving floor as it looks fancy
        if(dead.isDead)
        {
            CancelInvoke("CreatePipes");
        }
    }

    //Instantiating the pipes and floors prefabs
    void CreatePipes() {
        Instantiate(pipes);
    }
    void CreateFloor() {
        Instantiate(floor);
    }
}
