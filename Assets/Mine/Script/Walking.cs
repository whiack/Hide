using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

    public float speed;
	
	// Update is called once per frame
	void Update () {

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        if(Input.GetKeyDown("w")){
            transform.position = new Vector3(x + speed, y, z);
        }

        if (Input.GetKeyDown("s"))
        {
            transform.position = new Vector3(x - speed, y, z);
        }

        if (Input.GetKeyDown("a"))
        {
            transform.position = new Vector3(x, y, z + speed);
        }

        if (Input.GetKeyDown("d"))
        {
            transform.position = new Vector3(x, y, z - speed);
        }
    }
}
