using UnityEngine;
using System.Collections;

public class ArrowTest : MonoBehaviour {

    public GameObject wave;

    float timer;

	void Start () {
	
	}
	
	
	void Update () {

        timer += Time.deltaTime;

        if (timer > 0.3f)
        {
          GameObject w = (GameObject) Instantiate(wave, transform.position, transform.rotation);
        //  w.transform.parent = transform;
            timer = 0;
        }

	}
}
