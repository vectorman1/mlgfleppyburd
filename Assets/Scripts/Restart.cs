using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	// Use this for initialization
    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
    }
    void Update()
    {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        if(bird.isDead)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        }

    }
	void OnMouseDown()
    {
        GameObject go = GameObject.Find("Burd");
        Control bird = go.GetComponent<Control>();
        if (bird.isDead) { Application.LoadLevel("menu"); }

    }
    IEnumerable LoadLevel1()
    {
        AsyncOperation async = Application.LoadLevelAsync("main");
        yield return async;
    }
}
