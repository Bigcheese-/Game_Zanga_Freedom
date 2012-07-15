using UnityEngine;
using System.Collections;

public class GameStats : MonoBehaviour {


    public static int score;
    public static int lives;
    public static int combo;
    public static int level, maxLevel;
    public static int savedPeople;

    public static int experience,maxExperience;

    public static float infulence;
   
	void Start () {

        init();

	}

    void init()
    {
        savedPeople = 0;
        experience = 0;
        maxExperience = 100;
        score = 0;
        combo = 1;
        level = 1;
        maxLevel = 10;
        lives = 3;
        infulence = 100;
      
    }
	
	void Update () {
	
	}
}
