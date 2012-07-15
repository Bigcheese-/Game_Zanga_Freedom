using UnityEngine;
using System.Collections;

public class PoliceEnemy : Enemy {

    public tk2dAnimatedSprite sprite;
    public Transform toFollow;

	void Start () {
     
        init();

	}
	
	void FixedUpdate () 
    {
        if (!illuminated)
        {
            if (toFollow)
                agent.destination = toFollow.position;
            else agent.destination = CharacterControl.playerPos;
        }
	}

    public override void OnTriggerEnter(Collider col)
    {
        base.OnTriggerEnter(col);

        if (col.tag == "Player")
        {
            sprite.Play(1);
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            sprite.Play(0);
        }
    }

}
