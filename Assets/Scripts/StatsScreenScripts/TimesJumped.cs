using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TimesJumped : MonoBehaviour {

    Text timesJumped;

    // Use this for initialization
    void Start()
    {
        timesJumped = GetComponent<Text>();
        timesJumped.text = PlayerPrefs.GetInt("TimesJumped").ToString();
    }
}
