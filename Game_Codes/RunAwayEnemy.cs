using UnityEngine;
using System.Collections;

public class RunAwayEnemy : Enemy {

    public tk2dAnimatedSprite animGray;
    public tk2dAnimatedSprite animColor;

    public enum State {wait,chase, runAway };
    public State state = State.chase;

    float timer;

	void Start () {

        init();

	}
	
	public override void Update () {

        base.Update();

        switch (state)
        {
            case State.wait:
                {
                    timer += Time.deltaTime;

                    if (timer > 5)
                    {
                        state = State.chase;
                        timer = 0;
                    }
                    
                }
                break;

            case State.chase:
                {
                    moveTowardsPlayer();

                    if ((thisTransform.position - CharacterControl.playerPos).sqrMagnitude < 30)
                    {
                        state = State.runAway;
                    }
                    
                }
                break;

            case State.runAway:
                {
                    setRndTarget();
                    state = State.wait;
                }
                break;
        }


        //if (illuminated)
        //{
        //    return;
        //}

        //if ((thisTransform.position - CharacterControl.playerPos).sqrMagnitude < 50)
        //{
          

        //}
        //else if (agent.remainingDistance < 1)
        //{
           

        //}
        

     

	}

  

}
