using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour {

	// Use this for initialization
	void Start () {

        int record = PlayerPrefs.GetInt("Record");

        Text t = this.gameObject.GetComponent<Text>();
        t.text = "Highest Score: " + record.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
