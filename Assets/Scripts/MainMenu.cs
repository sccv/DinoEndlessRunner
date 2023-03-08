using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject choosingDinoScreen;
    public GameObject guidingScreen;

    public void PlayGame()
    {
        /*
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
        */
        startScreen.SetActive(false);
        choosingDinoScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChooseDino()
    {
        DinoCarrier.carrierInstance.DinoChosen = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
       
        choosingDinoScreen.SetActive(false);
        guidingScreen.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Main");
        Time.timeScale = 1f;
    }
}
