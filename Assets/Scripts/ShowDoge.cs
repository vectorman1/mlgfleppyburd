using UnityEngine;
using System.Collections;

public class ShowDoge : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        if (bird.isDead && bird.score >= 15 && bird.score < 20) GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
	}
}
