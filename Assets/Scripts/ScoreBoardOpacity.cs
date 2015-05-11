using UnityEngine;
using System.Collections;

public class ScoreBoardOpacity : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();

        if(bird.isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            if (bird.score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", bird.score);
            }
        }
	}
}
