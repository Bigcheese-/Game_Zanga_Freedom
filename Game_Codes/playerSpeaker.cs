using UnityEngine;
using System.Collections;

public class playerSpeaker : MonoBehaviour {

    public GameObject Wave;

    public float waveRate;

    float timer;

	void Start () {
	
	}
	
	void Update () {
	
      
        if (Time.time > timer)
        {
           GameObject wave = Instantiate(Wave, transform.position, transform.rotation) as GameObject;
           
            wave.transform.Rotate(Vector3.right * 90);
           
            wave.transform.parent = transform.parent;

            timer = Time.time + waveRate;
        }

	}
}
