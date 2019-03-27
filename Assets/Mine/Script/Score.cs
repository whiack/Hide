using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	
    private static int s;
    public Text score;

    private void Start()
    {
        s = 0;
    }

    public static int GetScore () {
        return s;
    }

    public static void IncreaseScore() {
        s += 10;
    }

    private void Update()
    {
        score.text = "Score: " + s;
        PlayerPrefs.SetInt("Score",s);
    }

}
