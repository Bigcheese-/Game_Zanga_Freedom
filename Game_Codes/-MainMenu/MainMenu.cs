using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    bool ishowToPlay;
    public GameObject HowtoPlayObj;

    bool isCredit;
    public GameObject CreditObj;

    bool showCredits;



	void Start () {
        Time.timeScale = 1;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if(Input.GetKeyDown(KeyCode.Escape) && showHoToPlay)
        {
            showHoToPlay = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && showCredits)
        {
            showCredits = false;
        }
        
        if (showCredits)
        {
            creditScreen.offset.y = Mathf.Lerp(creditScreen.offset.y, 0, Time.smoothDeltaTime * 5);
        }
        else creditScreen.offset.y = Mathf.Lerp(creditScreen.offset.y, -1000, Time.smoothDeltaTime * 5);


        if (showHoToPlay)
        {
            howToPlayScreen.offset.y = Mathf.Lerp(howToPlayScreen.offset.y, 0, Time.smoothDeltaTime * 5);
        }
        else
        {
            howToPlayScreen.offset.y = Mathf.Lerp(howToPlayScreen.offset.y, -1000, Time.smoothDeltaTime * 5);
        }

	}

    void LoadGame()
    {
        Application.LoadLevel(1);
    }


    public tk2dCameraAnchor creditScreen;

    void TeamCredit()
    {
        showCredits = true;
    }

    public tk2dCameraAnchor howToPlayScreen;
    bool showHoToPlay;
   
    void HoToplay()
    {
        showHoToPlay = true;
    }
}
