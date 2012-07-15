using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {


    public GameObject spark;

    public float speed;
    public float LifeTime;

    float lifeTimeCounter;

    public float scaleSpeed;
    public Vector3 targetScale;

    tk2dBaseSprite sprite;
    Color transparent;


    Transform thisTransform;
    Vector3 dir;
    int hits;

	void Start () {


        lifeTimeCounter = LifeTime;

        transparent = new Color(1, 1, 1, 0);
        sprite = gameObject.GetComponent<tk2dBaseSprite>();

        this.tag = "bullet";

        dir = Vector3.up;
        dir = dir * Time.smoothDeltaTime * speed;

        thisTransform = this.transform;
        thisTransform.eulerAngles = new Vector3(90, thisTransform.eulerAngles.y, thisTransform.eulerAngles.z);
	}

	void FixedUpdate () {

        lifeTimeCounter -= Time.deltaTime;

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.smoothDeltaTime * scaleSpeed);
        thisTransform.Translate(dir, Space.Self);

        if (lifeTimeCounter < (LifeTime / 3))
            if (sprite)
                sprite.color = Color.Lerp(sprite.color, transparent, Time.smoothDeltaTime );

        if (lifeTimeCounter < 0)
            Destroy(gameObject);

	}

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ignorant")
        Destroy(gameObject);

        if(spark)
            Instantiate(spark, thisTransform.position, Quaternion.identity);

     
       
    }

}
