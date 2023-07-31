using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.Events;



public class GameMenu : MonoBehaviour
{

    [SerializeField] private GameObject titleOne;
    [SerializeField] private GameObject homeButton;
    [SerializeField] private GameObject newTitle;
    [SerializeField] private GameObject backButton;
    [SerializeField] private GameObject settingsButton;
    [SerializeField] private GameObject restartButton;

    private bool settingsOpen = false;

    void Update()
    {
        if(settingsOpen == true)
        {
            titleOne.SetActive(false);
            homeButton.SetActive(false);
            settingsButton.SetActive(false);
            restartButton.SetActive(false);

            newTitle.SetActive(true);
            backButton.SetActive(true);

        }else if(settingsOpen == false)
        {
            titleOne.SetActive(true);
            homeButton.SetActive(true);
            settingsButton.SetActive(true);
            restartButton.SetActive(true);

            newTitle.SetActive(false);
            backButton.SetActive(false);
        }
    }

    public void LoadPreviousScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void refresh()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SettingsOpen()
    {
        if(settingsOpen == false)
        {
            settingsOpen = true;

        }else if(settingsOpen == true)
        {
            settingsOpen = false;
        }

    }

}
