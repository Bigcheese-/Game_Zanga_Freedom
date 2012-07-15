using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {


    void restartGame()
    {
        Application.LoadLevel(1);
    }

    void quitInGame()
    {
        Application.LoadLevel(0);
    }
}
