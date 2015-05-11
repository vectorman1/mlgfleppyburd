using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimesDied : MonoBehaviour {
    
    Text timesDied;

	// Use this for initialization
	void Start () {
        timesDied = GetComponent<Text>();
        timesDied.text = PlayerPrefs.GetInt("TimesDied").ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
