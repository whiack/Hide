using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour {


	// Use this for initialization
	void Start () {

        int record = PlayerPrefs.GetInt("Record");
        int score = PlayerPrefs.GetInt("Score");

        if(record < score) {
            PlayerPrefs.SetInt("Record", score);
        }

        Text t = this.gameObject.GetComponent<Text>();
        t.text = "Your Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
