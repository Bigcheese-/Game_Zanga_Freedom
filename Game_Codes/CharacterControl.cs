using UnityEngine;
using System.Collections;
using System;

public class CharacterControl : MonoBehaviour
{

    public float speed;

    Vector3 target;
    CharacterController character;

    public static Vector3 playerPos;

    Transform thisTransform;

	void Start () {

        thisTransform = this.transform;

        character = GetComponent<CharacterController>();

	}

	void FixedUpdate () {

        if (Mind.gameOver || Mind.pauseGame)
            return;

        LookAtMouse();

        if (Input.GetKey(KeyCode.W))
        {
         
            character.Move(Vector3.forward * speed);
        }

        if (Input.GetKey(KeyCode.S))
        {
           
            character.Move(Vector3.forward * -speed);
        }

        if (Input.GetKey(KeyCode.A))
        {
           
            character.Move(Vector3.right * -speed);
        }

        if (Input.GetKey(KeyCode.D))
        {
           
            character.Move(Vector3.right * speed);
        }

        playerPos = thisTransform.position;

        if (transform.position.y != 1)
        {
            transform.position = new Vector3(transform.position.x, 1, transform.position.z);
        }

	}

    void LookAtMouse()
    {

        target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        target.y = transform.position.y;

        if( (target - playerPos).sqrMagnitude > 0.2f)
        transform.LookAt(target);

    }
     

}
