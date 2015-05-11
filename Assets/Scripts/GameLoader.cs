using UnityEngine;
using System.Collections;

public class GameLoader : MonoBehaviour {

	//Script for the loading scene
    IEnumerator Start()
    {
        AsyncOperation async = Application.LoadLevelAsync("main");
        yield return async;
        Debug.Log("Loading Complete");
    }
	// Update is called once per frame
	void Update () {
	    if(Application.GetStreamProgressForLevel("main") == 1)
        {
            Application.LoadLevel("main");
        }
	}
}
