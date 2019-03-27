using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightWalking : MonoBehaviour {


    public float movementSpeed;
    // Update is called once per frame

    void Update () {
        transform.Translate(Vector3.forward * movementSpeed);
    }
}
