using UnityEngine;
using System.Collections;

public class RandomMove : MonoBehaviour {

    public Transform target;

    public float height;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;

    public float shakeTime, shakeStrength;

    public static bool shakeCamera;

    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;

    }



    void ShakeCamera()
    {

        //if (rigidbody)
        //    rigidbody.AddForce(new Vector3(Random.Range(-1, 1) * shakeStrength, Random.Range(-1, 1) * shakeStrength, 0));

        //if (transform.position.y != originalPos.y || transform.position.x != originalPos.x)
        //{
        //    if (rigidbody)
        //        rigidbody.AddForce( (originalPos - transform.position)*shakeStrength );
        //}
       // shakeTime -= Time.deltaTime * 5;
       //// shakeStrength -= Time.deltaTime;

       // transform.Translate(Random.Range(-shakeStrength, shakeStrength), Random.Range(-shakeStrength, shakeStrength),0 );

       // if (shakeTime <= 0)
       // {
       //     shakeTime = 0.5f;
       //     shakeStrength = 0.3f;
       //     shakeCamera = false;
       // }

    }



    void FixedUpdate()
    {
        ShakeCamera();
        
    }
}
