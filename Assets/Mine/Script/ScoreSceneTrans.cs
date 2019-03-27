using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSceneTrans : MonoBehaviour
{
    public string sceneName;
    public int passScor;

    // Update is called once per frame
    void Update()
    {
        int s = Score.GetScore();
        if(s == passScor) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
