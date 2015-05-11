using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(AudioSource))]
public class Control : MonoBehaviour {

    void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Screenmanager Resolution Width", 1080);
        PlayerPrefs.SetInt("Screenmanager Resolution Height", 1920);
        PlayerPrefs.SetInt("Screenmanager Is Fullscreen mode", 0);
    }
    //snewpdoge dog
    public bool isHigh = false;
    public int whenHigh = 0;

    //Setting the GameObjects of the get ready and the tap to play sprites so I can delete them after we start playing
    public GameObject getReadySign;
    public GameObject tutorial;
    
    //Deleting the score in the middle once the bird is dead so its not as ugly
    public GameObject text;
    public GameObject textShadow;
    bool destroyed = false;

    //So I don't add too much deaths when I hit the collision
    bool added = false;

    //Really strange issues when drawing the NEW highscore sprite so I made a bool for it
    public bool newHighScore = false;

    //Jump speed
    public Vector2 jumpForce = new Vector2(0, 300);
    
    //initialising the game with a isDead = false birdie, when this goes to true stuff happens
    public bool isDead = false;
    
    //I think it's obvious
    public int score = 0;
    
    //Generating all the AudioClips for all the audios played in the game.
    public AudioClip hitmarker;
    public AudioClip trumpet;
    public AudioClip wally;
    public AudioClip sadViolin;
    public AudioClip snewp;
    public AudioClip point;
    //////////////////////////////////////////////////////////////////////
    
    //Generating all the audiosources used to play them
    AudioSource snewpAudio;
    AudioSource hitmarkerAudio;
    AudioSource trumpetAudio;
    AudioSource wallyAudio;
    AudioSource sadViolinAudio;
    AudioSource pointAudio;
    //////////////////////////////////////////////////////////////////////

    //I need these bools to check whether or not the music has been played so that it doesnt flood with sound.
    private bool musicPlayed = false;
    private bool hitPlayed = false;
    
    //i is for roundrobin-ing the sounds when you jump
    private int i;

	void Start () {
        
        //The game is frozen while you don't tap.
        Time.timeScale = 0;
        
        //Initializing all the audios with the AudioSource component of the object.
        hitmarkerAudio = GetComponent<AudioSource>();
        trumpetAudio = GetComponent<AudioSource>();
        wallyAudio = GetComponent<AudioSource>();
        sadViolinAudio = GetComponent<AudioSource>();
        snewpAudio = GetComponent<AudioSource>();
        pointAudio = GetComponent<AudioSource>();
        
        //Background music ftw- snewwwwwwwp
        snewpAudio.PlayOneShot(snewp);
	}

	// Update is called once per frame
	void Update () {
        //Quit the game if escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape)) Application.Quit();

	    //Mouse left button click/space jump - we check every frame and if anyone of these are pressed -
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) && !isDead)
        {
            //This is only ran the first time the game starts - we delete the tutorial and the get ready sign
            if(Time.timeScale == 0)
            {
                GetComponent<Rigidbody2D>().isKinematic = false;
                Time.timeScale = 1;
                Destroy(getReadySign);
                Destroy(tutorial);
                if (!PlayerPrefs.HasKey("TimesJumped")) PlayerPrefs.SetInt("TimesJumped", 0);
                if (!PlayerPrefs.HasKey("TotalPoints")) PlayerPrefs.SetInt("TotalPoints", 0);
                if (!PlayerPrefs.HasKey("TimesDied")) PlayerPrefs.SetInt("TimesDied", 0);
                //Ui ui = new Ui();
                //ui.instruction.text = "0";
            }
            Jump();

            //Stuff to make the sounds when jumping randomized - WIP
            int randomNumber = Random.Range(0, 3);
            if (randomNumber == 0) hitmarkerAudio.PlayOneShot(hitmarker, 0.4f);
                else if (randomNumber == 1) trumpetAudio.PlayOneShot(trumpet, 0.4f);
                else if (randomNumber == 2) wallyAudio.PlayOneShot(wally, 0.8f);

            //For some reason they are hella laggy - not synchronized with jumps but w/e THEY WORK!
        }
        
        //Rotation of the bird... Dunno how it works, took it from Google.
        if (GetComponent<Rigidbody2D>().velocity.y > 0)
        {
            float angle1 = Mathf.Lerp(0, 45, (GetComponent<Rigidbody2D>().velocity.y / 3f));
            transform.rotation = Quaternion.Euler(0, 0, angle1);
        }
        else
        {
            float angle = Mathf.Lerp(0, -60, (-GetComponent<Rigidbody2D>().velocity.y / 3f));
            transform.rotation = Quaternion.Euler(0, 0, angle);
        
        }
        //if (sadViolinAudio.isPlaying && isDead) Application.LoadLevel(Application.loadedLevel);
	}
    //Normal Y speed increase function
    void Jump()
    {
        //We add 1 to the total count of times jumped in the playerprefs key "TimesJumped"
        int addJump = 1;
        PlayerPrefs.SetInt("TimesJumped", (PlayerPrefs.GetInt("TimesJumped") + addJump));

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        GetComponent<Rigidbody2D>().AddForce(jumpForce);
    }

    //Detection if we hit something, if we do, call Die();
    void OnCollisionEnter2D()
    {
        isDead = true;
        if (isDead && !hitPlayed) { hitmarkerAudio.PlayOneShot(hitmarker); hitPlayed = true; }
        Die();
    }

    //If we hit a box trigger with the tag "score", count score++
    void OnTriggerEnter2D(Collider2D other)
    {
        //We check if the trigger is "score", if it is, we add 1 point to the total score of the player and play the sound.
        if(other.gameObject.CompareTag("score") && !isDead)
        {
            
            score++;
            pointAudio.PlayOneShot(point, 0.5f);
        }
    }

    //This is the function which tells what happens when we die.
    void Die()
    {
        //If we are dead and we have yet to play the violin music, stop snewp dogge dog and start the violin.
        if (isDead && !musicPlayed)
        {
            snewpAudio.Stop();
            sadViolinAudio.PlayOneShot(sadViolin);
            musicPlayed = true;
            
        }

        int addDeath = 1;
        int addScore = score;
        if (!added && isDead)
        {
            PlayerPrefs.SetInt("TimesDied", (PlayerPrefs.GetInt("TimesDied") + addDeath));
            PlayerPrefs.SetInt("TotalPoints", addScore + PlayerPrefs.GetInt("TotalPoints"));
            added = true;
        }
        //Just make a key for the highscore so we can save it for later.
        if(!PlayerPrefs.HasKey("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", 0);
        }

        //Here we clear the score counter in the middle of the screen as we don't need it.
        if(isDead && !destroyed)
        {
            Destroy(text);
            Destroy(textShadow);
            destroyed = true;           
        }
    }
}
