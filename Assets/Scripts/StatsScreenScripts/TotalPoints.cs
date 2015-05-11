using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalPoints : MonoBehaviour {

    Text totalPoints;

    // Use this for initialization
    void Start()
    {
        totalPoints = GetComponent<Text>();
        totalPoints.text = PlayerPrefs.GetInt("TotalPoints").ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
