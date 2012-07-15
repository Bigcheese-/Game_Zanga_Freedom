using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {


    public tk2dAnimatedSprite character;

    Transform thisTransform;



	void Start () {


        thisTransform = transform;
        
	}
	
	
	void Update () {

        if (thisTransform.eulerAngles.y > 0 && thisTransform.eulerAngles.y < 72)
        {
            
        }
       
	}
}
