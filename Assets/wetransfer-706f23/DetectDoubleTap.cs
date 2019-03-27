using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDoubleTap : MonoBehaviour
{
    [Header("Check If Double-Tapped")]
    public KeyCode[] allKeys;

    [Header("Max Time Between Two Taps")]
    public float maxInterval;

    //[Header("Double-Tapped Keys")]
    //[HideInInspector]
    public KeyCode doubleTappedKey=KeyCode.None;

    public KeyCode firstKey;
    public KeyCode secondKey;
    private float timePassed;
    private bool firstKeyPressed=false;

    private void Update()
    {
        if(firstKeyPressed==false)
        {
            RecordFirstInput();
        }
        else
        {
            CountDownTime();
            CheckTimePassed();
            RecordSecondInput();
        }
    }

    private void RecordFirstInput()
    {
        if(Input.anyKeyDown)
        {
            foreach (var keyCode in allKeys)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    firstKeyPressed = true;
                    firstKey = keyCode;
                    ResetTimePassed();
                    break;
                }
            }
        }
    }

    private void CountDownTime()
    {
        timePassed += Time.deltaTime;
    }

    private void ResetTimePassed()
    {
        timePassed = 0;
    }

    private void CheckTimePassed()
    {
        if (timePassed > maxInterval)
        {
            firstKeyPressed = false;
            ResetKeys();
        }
            
    }

    private void RecordSecondInput()
    {
        if(Input.anyKeyDown)
        {
            foreach (var keyCode in allKeys)
            {
                if (Input.GetKeyDown(keyCode))
                {
                    firstKeyPressed = false;
                    secondKey = keyCode;
                    break;
                }
            }
        }

        if (firstKey == secondKey)
        {
            doubleTappedKey = firstKey;
        }
        
        if(secondKey!=KeyCode.None)
        {
            ResetKeys();
        }
    }

    public void ResetDoubleTappedKey()
    {
        doubleTappedKey = KeyCode.None;
    }

    private void ResetKeys()
    {
        firstKey = KeyCode.None;
        secondKey = KeyCode.None;
    }

}
