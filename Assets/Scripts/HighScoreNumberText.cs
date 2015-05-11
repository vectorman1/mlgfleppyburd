using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoreNumberText : MonoBehaviour
{
    Text highScore;

    //We initialize the highscore field. 
    void Start()
    {
        highScore = GetComponent<Text>();
    }

    void Update()
    {

        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();

        //If the bird is dead and we have a new high score - we save it and write it.
        //If not, we just get the highscore so far and write it instead.
        if(bird.score > PlayerPrefs.GetInt("HighScore") && bird.isDead)
        {
                     
            highScore.text = bird.score.ToString();
            PlayerPrefs.SetInt("HighScore", bird.score);        
        }
        else if (bird.isDead)
        {
            highScore.text = PlayerPrefs.GetInt("HighScore").ToString();
        }

    }
}
