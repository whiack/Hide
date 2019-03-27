using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_Main : MonoBehaviour
{
    [Header("Distance Dashed in Meters")]
    public float dashDistance;
    //[Tooltip("The smaller the time, the faster it dashes")]
    //[Header("Dash Time Taken")]
    //public float dashInterval;
    [Header("Dash CoolDown")]
    public float coolDownTime;
    [Header("Dash Direction")]
    public Dash_Support[] inputToDirections;

    public float xMax;
    public float xMin;
    public float zMax;
    public float zMin;


    private DetectDoubleTap detectDoubleTap;
    private bool readyToDash = true;
    private Rigidbody rb;
    private Rigidbody2D rb2d;
    private bool is2DGame;
    private Vector3 defaultDirection = new Vector3(-999, -999, -999);
    private Vector3 direction;//= new Vector3(-999,-999,-999);
    private float timePassed;

    private void Start()
    {
        DoubleTapComponent();
        RigidBody();

        direction = defaultDirection;
    }
    private void Update()
    {
        if(readyToDash)
        {
            InputDirection();
            StartDash();
        }
        else
        {
            ResetCooldown();
        }
    }

    private void DoubleTapComponent()
    {
        detectDoubleTap = GetComponent<DetectDoubleTap>();
    }
    private void RigidBody()
    {
        if(GetComponent<Rigidbody>()==null)
        {
            //We are in a 2D world
            is2DGame = true;
            rb2d = GetComponent<Rigidbody2D>();
        }
        else
        {
            //We are in a 3D world
            is2DGame = false;
            rb = GetComponent<Rigidbody>();
        }
    }
    private void InputDirection()
    {
        if(detectDoubleTap.doubleTappedKey!=KeyCode.None)
        {
            foreach(var inputToDirection in inputToDirections)
            {
                if(inputToDirection.inputKey == detectDoubleTap.doubleTappedKey)
                {
                    direction = inputToDirection.dashDirection;
                    //Debug.Log("Dash to: " + direction);
                    break;
                }
            }
        }
    }
    private void StartDash()
    {
        if (direction == defaultDirection)
            return;
        Vector3 dashPosition = transform.position + direction.normalized * dashDistance;
        Debug.Log("position" + dashPosition);
        if (dashPosition.x > xMax || dashPosition.x < xMin || dashPosition.z > zMax || dashPosition.z < zMin)
            return;

        //Debug.Log("Current Direction: " + direction);

        if (is2DGame)
        {
            rb2d.MovePosition(transform.position + direction.normalized * dashDistance);
        }
        else
        {
            rb.MovePosition(transform.position + direction.normalized * dashDistance);
        }

        readyToDash = false;
        ResetDiretion();
        detectDoubleTap.ResetDoubleTappedKey();
    }
    private void ResetCooldown()
    {
        timePassed += Time.deltaTime;

        if (timePassed>=coolDownTime)
        {
            timePassed = 0;
            readyToDash = true;
        }
    }
    private void ResetDiretion()
    {
        direction = defaultDirection;
    }
}
