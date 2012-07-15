using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

    public GameObject wave;

    public float fireRate;
    float timer;

    int L;
    bool mouseUp;
    float defaultVolume;

    public AudioClip[] sounds;


    void Start () {
        
        mouseUp = true;
        defaultVolume = audio.volume;
     
	}

	void FixedUpdate () {

        if (Time.time > timer)
        {
            if (Input.GetMouseButton(0))
            {
                GameObject bullet = Instantiate(wave, transform.position, transform.rotation) as GameObject;
               
                mouseUp = false;

                timer = Time.time + fireRate;

            }
            else mouseUp = true;
            
        }

        if (mouseUp)
        {
            if (audio.volume > 0)
                audio.volume -= Time.deltaTime*2;

        }
        else if (mouseUp == false)
        {
            if (audio.volume < defaultVolume)
                audio.volume += Time.deltaTime * 2;

            if (audio.isPlaying == false)
            {
                int rnd = Random.Range(0, sounds.Length);
                audio.clip = sounds[rnd];
                audio.Play();
            }
        }

      


	}
}
