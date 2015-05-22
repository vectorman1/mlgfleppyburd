using UnityEngine;
using System.Collections;

public class YouStooped : MonoBehaviour {
   
    //We make an audioclip for the "u stooped" easter egg
    public AudioClip stooped;
    /////////////////////////////////////////////////////

    //And we make the audiosource for it aswell
    public AudioSource stoopedAudio;
    ///////////////////////////////////////////

    //I'm using this so I don't flood the app with the sound over and over again.
    public bool played = false;
	/////////////////////////////////////////////////////////////////////////////

	void Start () {
	    //Initializing the audiosource for the clip
        stoopedAudio = GetComponent<AudioSource>();    
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();

        //If the score is 21 and the sound has yet to be played -> play it.
        if (bird.score == 21 && !played)
        {
            stoopedAudio.PlayOneShot(stooped);
            played = true;
        }

	}
}
