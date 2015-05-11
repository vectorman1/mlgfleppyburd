using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ui : MonoBehaviour {
    public Text instruction;
	// Use this for initialization
    public AudioClip stooped;
    AudioSource stoopedAudio;
	void Start () {
        instruction = GetComponent<Text>();
        stoopedAudio = GetComponent<AudioSource>();
	}
    bool played = false;
	// Update is called once per frame
	void Update () {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();



        
        if (bird.score > 21 && Time.timeScale == 0.5f) Time.timeScale = 1;
        else if (bird.score > 21 || bird.score < 21 && bird.score != 0)
        {
            instruction.text = bird.score.ToString();

        }
        if (played) Time.timeScale = 1;
        if (bird.score == 21)
        {
            Debug.Log("If Paseed");
            Time.timeScale = 0.35f;
            instruction.text = "9 + 10";
            played = true;
        }
        
	}
}
