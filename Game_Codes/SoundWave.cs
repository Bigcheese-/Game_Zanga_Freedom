using UnityEngine;
using System.Collections;

public class SoundWave : MonoBehaviour {

 

    public float speed;
    public float scaleSpeed;
    public Vector3 targetScale;
    public float LifeTime;

    float lifeTime;

    tk2dBaseSprite sprite;
    Color transparent;

	void Start () {

        transparent = new Color(1, 1, 1, 0);
        sprite = gameObject.GetComponent<tk2dBaseSprite>();

	}

	void FixedUpdate () {

        transform.Translate(Vector3.up*Time.smoothDeltaTime*speed, Space.Self);

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.smoothDeltaTime * scaleSpeed);

        lifeTime += Time.deltaTime;

        if (lifeTime > (LifeTime/2))
            if (sprite)
                sprite.color = Color.Lerp(sprite.color, transparent, Time.smoothDeltaTime * 10);

        if (lifeTime > LifeTime)
            Destroy(gameObject);

	}
}
