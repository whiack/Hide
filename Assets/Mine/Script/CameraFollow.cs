using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    [Range (0,1)] public float followSpeed;
    public float camPosY;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void LateUpdate () {
        Vector3 newCamPos = Vector3.Lerp(transform.position, player.transform.position, followSpeed);
        newCamPos.y = camPosY;
        transform.position = newCamPos;
    }
}
