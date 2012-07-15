using UnityEngine;
using System.Collections;

public class Mind : MonoBehaviour {

    public GameObject[] Enemies;

    public Transform[] spawnPoints;
    public static Transform[] staticSpawnPoints;

    public GameObject wiseMan;

    public static bool gameOver;
    public static bool pauseGame;

    public int maxOnScreenEnemies;
    public float spawnFrequency;
    public float distanceThreshold;

    int generatedEnemies;
    static int onScreenEnemies;

    float spawnTimer;

    private int rndPercent, runPercent, chasePercent, policePercent;

    static float comboTimer;

    public GUIManager guiManager;
    public Shooting shooting;

    public static bool increaseLevel;

    GameObject parentOfAll;


	void Start () {

        parentOfAll = new GameObject("ParentOfAll");

        gameOver = false;
        pauseGame = false;
        Time.timeScale = 1;

        staticSpawnPoints = spawnPoints;
     
        generatedEnemies = 0;
        onScreenEnemies = 0;
        comboTimer = 0;

        spawnTimer = 0;

        rndPercent = 55;
        runPercent = 30;
        chasePercent = 15;
        policePercent = 0;

	}
	
	void Update () {

        if (Input.GetKeyUp(KeyCode.Escape))
        {

            if(pauseGame == true)
            {
                Time.timeScale = 1;

            pauseGame = false;
            gameObject.GetComponent<BlurEffect>().enabled = false;
            }
            else if(pauseGame == false)
            {

                gameObject.GetComponent<BlurEffect>().enabled = true;
                pauseGame = true;
            }
            
        }

        if (gameOver || pauseGame)
            return;

        SpawnLogic();

        ComboLogic();

        InfluenceLogic();

        if (GameStats.experience >= GameStats.maxExperience )
        {
            if (GameStats.level < GameStats.maxLevel)
            {
                LevelUp();
                SpawnPowerUp();
            }
            else
            {
                SpawnPowerUp();
                GameStats.experience = 0;
            }

        }
	}

    void InfluenceLogic()
    {
        if (GameStats.infulence <= 0)
        {
            RemoveLife();
        }
    }

    void RemoveLife()
    {
        onScreenEnemies = 0;
        Destroy(parentOfAll);
        parentOfAll = new GameObject("ParentOfAll");
        Camera.main.transform.position = CharacterControl.playerPos + Vector3.up * 2;
     
        GameStats.lives--;
        if (GameStats.lives >= 0)
        {
            
            Destroy(guiManager.livesSprites[GameStats.lives]);
          
        }

        if (GameStats.lives < 0)
        {
            GameOver();
        }
        else
        {
            GameStats.infulence = 100;
        }
    }

    void GameOver()
    {
        gameOver = true;
        gameObject.GetComponent<BlurEffect>().enabled = true;
    }

    void LevelUp()
    {
        if(spawnFrequency >= 1)
        spawnFrequency -= 0.25f;

        shooting.fireRate -= 0.05f;

        GameStats.experience = 0;
        GameStats.maxExperience += 100;

        GameStats.level++; 
 
        if(maxOnScreenEnemies < 120)
        maxOnScreenEnemies += 5;

        if(rndPercent >= 10)
        rndPercent -= 10;

        if (chasePercent < 30 && GameStats.level <= 7)
            chasePercent += 7;
        else chasePercent -= 5;

        if (policePercent < 30 && GameStats.level <= 7)
            policePercent += 3;
        else policePercent += 5;

      
    }

    public static void AddScore(int val)
    {
        if (comboTimer >= 0)
        {
            GameStats.combo++;
            comboTimer = 2;
        }
       
        GameStats.score += val* GameStats.combo;

        GameStats.savedPeople++;

        GameStats.experience += val;

        onScreenEnemies--;

    }

    void ComboLogic()
    {
        if (comboTimer >= 0)
        {
            comboTimer -= Time.deltaTime;
        }
        else
        {
            comboTimer = 0;
            GameStats.combo = 1;
        }

    }

    void SpawnLogic()
    {
            spawnTimer += Time.deltaTime;

            if (spawnTimer > spawnFrequency)
            {
                spawnEnemy(DecideSpawnEnemey(), DecideSpawnLocation());
                spawnTimer = 0;
            }

    }

    GameObject DecideSpawnEnemey()
    {
     
        int Rnd = Random.Range(0, 100);
        
        if (Rnd < rndPercent)
        {
            return Enemies[0];
        }
        else if (Rnd > rndPercent && Rnd < rndPercent + runPercent)
        {

            return Enemies[1];
        }
        else if (Rnd > (rndPercent + runPercent) && Rnd < rndPercent + runPercent + chasePercent)
        {
            return Enemies[2];
        }
        else
        {
            return Enemies[3];
        }

    }

    Vector3 DecideSpawnLocation()
    {
        ArrayList farSpawnPoints = new ArrayList();

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if ((CharacterControl.playerPos - spawnPoints[i].position).sqrMagnitude > distanceThreshold)
            {
                farSpawnPoints.Add(spawnPoints[i]);
            }
        }

        int rnd = Random.Range(0, farSpawnPoints.Count);
        return spawnPoints[rnd].position;

    }

    void spawnEnemy(GameObject obj, Vector3 spawnPoint)
    {

        if (onScreenEnemies > maxOnScreenEnemies)
            return;

        GameObject newEnemey = Instantiate(obj, spawnPoint, Quaternion.identity) as GameObject;
        newEnemey.transform.parent = parentOfAll.transform;
        generatedEnemies++;
        onScreenEnemies++;
    }

    void SpawnPowerUp()
    {
        GameObject powerUp = (GameObject)Instantiate(wiseMan, DecideSpawnLocation(), Quaternion.identity);
    }

}

/*

*/