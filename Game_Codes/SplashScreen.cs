using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

    tk2dSprite sprite;

    float timer;

	void Start () {
        
        sprite = gameObject.GetComponent<tk2dSprite>();
        timer = 0;

	}
	
	void Update () {

        timer += Time.deltaTime;

        if (timer > 2)
        {
            sprite.color = Color.Lerp(sprite.color, new Color(1, 1, 1, 0), Time.deltaTime*10);

            if (sprite.color.a < 0.1f)
            {
                Destroy(gameObject);
            }
        }
	}
}
