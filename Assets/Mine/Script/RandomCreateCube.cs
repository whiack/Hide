using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomCreateCube : MonoBehaviour {

    //public GameObject gb1;
    //public GameObject enemy;
    public GameObject explode;



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") {
            Vector3 randPosition1 = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));
            Vector3 randPosition2 = new Vector3(Random.Range(-9, 9), 0, Random.Range(-9, 9));

            //Instantiate(gb1, randPosition1, Quaternion.identity);
            //Instantiate(enemy, randPosition2, Quaternion.identity);

            Destroy(gameObject);
           

            //StartCoroutine(showExplosion());

            //explosion
            GameObject go = Instantiate(explode) as GameObject;
            go.transform.position = transform.position;
            Destroy(go, 1.0f);


            Score.IncreaseScore();
        }
    }

    IEnumerator showExplosion() {
        GameObject go = Instantiate(explode) as GameObject;
        go.transform.position = transform.position;
        yield return new WaitForSeconds(1);
        Destroy(go);
    }
}
