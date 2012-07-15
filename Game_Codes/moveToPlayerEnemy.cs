using UnityEngine;
using System.Collections;

public class moveToPlayerEnemy : Enemy {

	void Start () {

        init();

	}

    public override void Update()
    {
        base.Update();

        if (!illuminated)
        {
            agent.destination = CharacterControl.playerPos;
        }
 
	}

}
