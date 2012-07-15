using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public enum Type { Random, Attack, MoveAway };
    public Type enemyType;

    public int power;
    public float moveSpeed;
    public float bulletEffectVal;
  
    protected float illuminationLevel;
    protected bool illuminated;

    protected Transform thisTransform;
    protected NavMeshAgent agent;
    protected Color spriteColor;

    public tk2dAnimatedSprite ColoredSprite;
    public GameObject illuEffect;

    Vector3 agentTarget;

	void Start () {
       
	}
	
    public void init()
    {
        thisTransform = this.transform;

        if (gameObject.GetComponent<NavMeshAgent>())
            agent = gameObject.GetComponent<NavMeshAgent>();
        else 
        if (agent == null)
        {
            agent = gameObject.AddComponent<NavMeshAgent>();
            agent.speed = Random.Range(moveSpeed - 2, moveSpeed + 2);
            agent.angularSpeed = 200;
            agent.obstacleAvoidanceType = ObstacleAvoidanceType.MedQualityObstacleAvoidance;
        }

        if(ColoredSprite)
        spriteColor = ColoredSprite.color;
        
        illuminationLevel = 0;
        illuminated = false;

    }

    protected void setRndTarget()
    {
        if (!agent)
            return;

        if (agent.hasPath)
        {
            agent.ResetPath();
        }

        agentTarget = Mind.staticSpawnPoints[Random.Range(0, Mind.staticSpawnPoints.Length - 1)].position;
        agent.SetDestination(agentTarget);
    }

    protected void moveTowardsPlayer()
    {
        if (!agent)
            return;

            agentTarget = CharacterControl.playerPos;
            agent.destination = agentTarget;
        
    }

    public virtual void OnTriggerEnter(Collider col)
    {
        if (illuminated)
        {
            return;
        }

        if (col.tag == "bullet")
        {
            illuminationLevel += bulletEffectVal;
            
            if (illuminationLevel >= 1)
            {
                illuminated = true;

                tag = "Illuminated";

                Mind.AddScore(power);

               GameObject illu = (GameObject) Instantiate(illuEffect, transform.position, transform.rotation);
               illu.transform.parent = transform;

            }

            if (ColoredSprite)
            {
                spriteColor.a += bulletEffectVal;
                ColoredSprite.color = spriteColor;
            }

        }
    }


	public virtual void Update () {

        if (illuminated) // move towards the Square
        {
            agent.destination = Vector3.zero;

            if ((thisTransform.position.sqrMagnitude < 100))
                Destroy(gameObject);
        }
	}
}
