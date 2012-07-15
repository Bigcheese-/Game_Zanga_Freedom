using UnityEngine;
using System.Collections;

public class RandomNavigationEnemy : Enemy {

    Vector3 target;

	void Start () {

        init();

        setRndTarget();

	}

    public override void Update()
    {

        base.Update();

        if (!illuminated)
        {
            if (agent.remainingDistance < 2)
            {
                setRndTarget();
            }
        }
        
	}

  

}
