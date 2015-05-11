using UnityEngine;
using System.Collections;

public class EndGameRestart : MonoBehaviour {

	// Make the sprite invisible while you're playing
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	}
	
	// Checking if you're dead, if you are, make the sprite visible
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        if (bird.isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
	}
    void OnMouseDown()
    {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        //AND the sprite becomes clickable
        if(bird.isDead) Application.LoadLevel(Application.loadedLevel);
    }
}
