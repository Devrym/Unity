using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    public void StartGame()
    {
        Application.LoadLevel("Level_1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
