using UnityEngine;
using System.Collections;

public class playerCircle : MonoBehaviour {


    public PlayerStats playerStats;

    ArrayList list;

	void Start () {

	}
	

	void Update () {

	}

    
    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Ignorant":
                {
                    playerStats.enemies.Add(col.transform);
                }
                break;

            case "WiseMan":
                {
                    col.gameObject.GetComponent<WiseMan>().collected = true;
                    GameStats.infulence = 100;
                }
                break;

        }
     
    }

}
