using UnityEngine;
using System.Collections;

public class DeleteKeys : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
