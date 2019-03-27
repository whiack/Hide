using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {

    private static int t;

    private void Start()
    {
        t = 0;
    }

    public int GetScore()
    {
        return t;
    }

    public static void IncreaseScore()
    {
        t -= 0;
    }

 
}
