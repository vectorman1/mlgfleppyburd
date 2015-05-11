using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreBoardScore : MonoBehaviour {
    Text scoreBoardScore;

	// Use this for initialization
    void Start()
    {
        scoreBoardScore = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        if(bird.isDead)
        {
            scoreBoardScore.text = bird.score.ToString();
        }

	}
}
