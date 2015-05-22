using UnityEngine;
using System.Collections;

public class WeedController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
        Debug.Log("Transparent Weed");
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();

        if(bird.score % 5 == 0 && bird.score != 0 && bird.isHigh)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }
        if (bird.isHigh && !(bird.score % 5 == 0)) GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	}
}
