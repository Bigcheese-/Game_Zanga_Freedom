using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    public Light spotLight;
    public float Health;

    public int enemiesInsideCircle;

    public ArrayList enemies = new ArrayList();

	void Start () {
	
	}
	
	void Update () {

        if (enemies.Count > 0)
        {
            GameStats.infulence -= Time.deltaTime*enemies.Count;

            foreach (Transform obj in enemies)
            {
                if (obj == null)
                {
                    enemies.Remove(obj);
                    break;
                }
                else
                {
                    if ((obj.position - transform.position).sqrMagnitude > 15 || obj.tag == "Illuminated")
                    {
                        enemies.Remove(obj);
                        break;

                    }
                }
            }

            spotLight.color = Color.Lerp(spotLight.color, Color.red, Time.smoothDeltaTime * 5);

        }
        else
        {
            if (spotLight.color.r < 250)
            {
                spotLight.color = Color.Lerp(spotLight.color, Color.white, Time.smoothDeltaTime * 5);

            }
        }

	}

    void OnTriggerEnter(Collider col)
    {
        switch (col.tag)
        {
            case "Ignorant":
                {

                    GameStats.infulence -= col.GetComponent<Enemy>().power;
                    CameraFollow.shakeCamera = true;
                    GUIManager.animateBar = true;
                    audio.Play();
                }
                break;

        }
    }

   
}
