using UnityEngine;
using System.Collections;

public class WiseMan : MonoBehaviour {

    public tk2dAnimatedSprite wiseManAni;
    public tk2dSprite circle;

    public float Timer;
    
    public Transform arrow;

    Color color;

    SoundWave waveEffect;

    public bool collected;

	void Start () {

        color = circle.color;
        waveEffect = circle.GetComponent<SoundWave>();
        waveEffect.enabled = false;

        arrow.parent = null;

	}
	
	void Update () {

        Timer -= Time.deltaTime;

        if (Timer < 2)
        {
            if (waveEffect)
                if (waveEffect.enabled == false)
                {
                    color.a = Mathf.PingPong(Time.time, 0.5f) + 0.5f;
                    circle.color = color;
                }
        }

        if (Timer <= 0)
        {
            if(arrow)
            Destroy(arrow.gameObject);

            Destroy(gameObject);
        }
        else 
        if (collected)
        {
            audio.Play();

            if(circle)
            if (waveEffect.enabled == false)
                waveEffect.enabled = true;

            wiseManAni.Play(1);
            collected = false;

            if(arrow)
            Destroy(arrow.gameObject);

            Destroy(gameObject, 1);

            Mind.increaseLevel = true;
        }

        if (arrow)
        {
            arrow.transform.position = CharacterControl.playerPos;
            arrow.transform.LookAt(transform);
        }

       

	}

    
}
