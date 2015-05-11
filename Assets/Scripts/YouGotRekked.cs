using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class YouGotRekked : MonoBehaviour {
    
    //Create the text field.
    Text text;
	void Start () {
        //Initialize it
        text = GetComponent<Text>();

        //Give it an alpha ot zero so that it's transparent until we need it.
        Color thisColor = text.color;
        thisColor.a = 0f;
        text.color = thisColor;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();

        //If the bird is dead we make it able to see.
        if(bird.isDead)
        {
            Color thisColor = text.color;
            thisColor.a = 1f;
            text.color = thisColor;
        }
	}
}
