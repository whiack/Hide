using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnAround : MonoBehaviour {

    public GameObject gb1;
    public float angle;
    public string sceneName;
    public float speed;

    public GameObject face;

    private bool turn = false;
    private float rotationTime;
    private Quaternion targetR;

    private void Update()
    {
        //Debug.Log(rotationTime);
        //if (turn) {
        //    rotationTime += Time.deltaTime * speed;
        //    gb1.transform.rotation = Quaternion.Lerp(gb1.transform.rotation, targetR, rotationTime * speed);
        //}
        //if(rotationTime > 1) {
        //    turn = false;
        //    rotationTime = 0;
        //}


        if(turn) {
            rotationTime += Time.deltaTime * speed;
            gb1.transform.Rotate(new Vector3(0, speed, 0));
        }
        if (rotationTime > 1)
        {
            turn = false;
            rotationTime = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" || other.tag == "Enemy")
        {
            //targetR = Quaternion.Euler(0, angle, 0);
            turn = true;
            //Animator a = face.GetComponent<Animator>();
            //a.SetTrigger("trun");

            //gb1.transform.Rotate(new Vector3(0, angle, 0));
        }
        else if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(turn);
        if (other.tag == "Wall" || other.tag == "Enemy")
        {
            targetR = Quaternion.Euler(0, angle, 0);
            turn = true;

            //gb1.transform.Rotate(new Vector3(0, angle, 0));
        }
        else if (other.tag == "Player")
        {
            SceneManager.LoadScene(sceneName);
        }
    }


}
