using UnityEngine;
using System.Collections;

public class StartClick : MonoBehaviour {

	// Use this for initialization

    void OnMouseDown()
    {
        Application.LoadLevel("loading");
    }
	
}
