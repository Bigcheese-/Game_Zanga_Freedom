using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target; 

    public float height ;
    public float smoothTime = 0.3F;

    private Vector3 velocity = Vector3.zero;

    public float shakeTime, shakeStrength;

    public static bool shakeCamera;

	void Start () {
	
	}

     void ShakeCamera()
    {
        shakeTime -= Time.deltaTime*5;
        shakeStrength -= Time.deltaTime;

        transform.Translate(Random.Range(-shakeStrength, shakeStrength), 0, Random.Range(-shakeStrength, shakeStrength));

        if (shakeTime <= 0)
        {
            shakeTime = 0.5f;
            shakeStrength = 0.3f;
            shakeCamera = false;
        }
    }

	void FixedUpdate () {
        

        if (shakeCamera)
        {
            ShakeCamera();
        }
        
        Vector3 targetPosition = target.position + new Vector3(0, height, 0);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
       
	}
}
