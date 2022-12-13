using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject soundsMenu;


    public void StartGame()
    {
        Application.LoadLevel("Level_1");
    }

    public void OptionsGame()
    {
        mainMenu.SetActive(false);
        soundsMenu.SetActive(true);

    }

    public void BackMenuGame()
    {
        mainMenu.SetActive(true);
        soundsMenu.SetActive(false);

    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
