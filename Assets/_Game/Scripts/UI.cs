using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject pause;
    public GameObject gameOver;
    public GameObject gameplay;
    public GameObject mainMenu;


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Restart() {
        Time.timeScale = 1;
        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    [Button]
    public void MainMenu() {
        Time.timeScale = 0;
        mainMenu.SetActive(true);
        gameplay.SetActive(false);
        SceneManager.LoadScene(0);
    }

   
    public void Play() {
        Time.timeScale = 1;
        mainMenu.SetActive(false);
        gameplay.SetActive(true);
        SceneManager.LoadScene(1);
    }


    public void Quit() {
        Application.Quit();
    }
}
