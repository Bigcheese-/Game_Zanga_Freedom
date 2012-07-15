using UnityEngine;
using System.Collections;

public class GUIManager : MonoBehaviour {

    public tk2dCameraAnchor gameOverMenu;
    public tk2dCameraAnchor pauseMenu;

    public tk2dTextMesh scoreText, comboText,expText,levelText;

    public tk2dSprite[] livesSprites;

    int scoreCounter, comboCounter,levelCounter,expVal;
    float influenceCounter;

    public tk2dSprite influenceBar;
    Transform barTransform;
    Vector3 targetScale;

    public static bool animateBar;

    public bool GameOver;

    public Color barColor;

	void Start () {

        influenceBar.color = barColor;
        expVal = -1;
        barTransform = influenceBar.transform;
        targetScale = Vector3.one;
        comboCounter = 0;

	}


    void Exit()
    {
        Application.LoadLevel(0);
    }

    void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void ExperienceUpdate()
    {

        if (expVal != GameStats.experience )
        {
            expVal = GameStats.experience;

            switch (GameStats.experience.ToString().Length)
            {
                case 1:
                    {
                        expText.text = "00" + GameStats.experience + "   " + GameStats.maxExperience;
                        expText.Commit();
                    }
                    break;

                case 2:
                    {
                        expText.text = "0" + GameStats.experience + "   " + GameStats.maxExperience;
                        expText.Commit();
                    }
                    break;

                default:
                    {
                        expText.text = GameStats.experience + "   " + GameStats.maxExperience;
                        expText.Commit();
                    }
                    break;


            }
        }

       
       
    }

    void LevelUpdate()
    {
        if (levelCounter != GameStats.level)
        {
            levelCounter = GameStats.level;
            levelText.text = levelCounter.ToString();
            levelText.Commit();
        }
    }

    void influenceBarUpdate()
    {
        targetScale.x = Mathf.Lerp(targetScale.x, (GameStats.infulence / 100), Time.smoothDeltaTime * 2);
        barTransform.localScale = targetScale;

        if (animateBar)
        {
            influenceBar.color = Color.red;
            animateBar = false;
        }

        if (influenceBar.color.b < 1)
        {
            influenceBar.color = Color.Lerp(influenceBar.color, barColor, Time.smoothDeltaTime);
        }

    }

    void scoreUpdate()
    {
        if (scoreCounter < GameStats.score)
        {
            scoreCounter++;
            scoreText.text = scoreCounter.ToString();
            scoreText.Commit();
        }
    }

    void comboUpdate()
    {
        if (comboCounter != GameStats.combo)
        {
            if (comboCounter < GameStats.combo)
                comboCounter++;

            if (comboCounter > GameStats.combo)
                comboCounter--;

            comboText.text = "X " + comboCounter.ToString();
            comboText.Commit();
        }
    }

	void Update () {

        ExperienceUpdate();
        LevelUpdate();
        influenceBarUpdate();
        scoreUpdate();
        comboUpdate();

        if (Mind.pauseGame)
        {
            pauseMenu.offset.y = Mathf.Lerp(pauseMenu.offset.y, 0, Time.smoothDeltaTime * 5);

            if (pauseMenu.offset.y > -20)
            {
                Time.timeScale = 0;
            }

        }
        else
        {
            if(pauseMenu.offset.y > -900)
                pauseMenu.offset.y = Mathf.Lerp(pauseMenu.offset.y, -1000, Time.smoothDeltaTime * 5);
        }

        if (Mind.gameOver)
        {
            gameOverMenu.offset.y = Mathf.Lerp(gameOverMenu.offset.y, 0, Time.smoothDeltaTime * 5);
        }

	}
}
