using UnityEngine;
using System.Collections;

public class NewHighScore : MonoBehaviour {

    
    void Start()
    {
        //We initialize the sprite as transparent until we need it.
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        Debug.Log(bird.isDead);
        //If the bird's dead and the current score is higher than the saved highscore we make the sprite able-to-see.
        if (bird.isDead)
        {
            Debug.Log(PlayerPrefs.GetInt("HighScore"));
            if (bird.score == PlayerPrefs.GetInt("HighScore"))
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                Debug.Log("Is Visible now");
            }
        }
	}
}
