using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selector : MonoBehaviour
{
    public GameObject panel;
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    public GameObject image5;
    public GameObject image6;
    public string scene;
    public MedalManager medalManager;

    private float levelSelectStartTime;
    private bool levelSelectTimerRunning;

    public void Start()
    {
        levelSelectStartTime = Time.realtimeSinceStartup;
        levelSelectTimerRunning = true;

        panel.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
        image6.SetActive(false);
    }

    public void SeePanel()
    {
        panel.SetActive(true);
        image1.SetActive(true);
        image2.SetActive(true);
        image3.SetActive(true);
        image4.SetActive(true);
        image5.SetActive(true);
        image6.SetActive(true);
    }
 
    public void GoToScene1()
    {
        RegisterLevelSelectTime("level_1");

        AnalyticsManager.instance.ResetAttemptData();
        MedalManager.instance.ResetCoins();
        SceneManager.LoadScene("Level 1");
    }

    public void GoToMenu()
    {
        RegisterLevelSelectTime("main_menu");
        SceneManager.LoadScene("Main Menu");
    }

    public void ClosePanel()
    {
        panel.SetActive(false);
        image1.SetActive(false);
        image2.SetActive(false);
        image3.SetActive(false);
        image4.SetActive(false);
        image5.SetActive(false);
        image6.SetActive(false);
      
    }

    private void RegisterLevelSelectTime(string selectedLevelId)
    {
        if (!levelSelectTimerRunning)
            return;

        float elapsedTime = Time.realtimeSinceStartup - levelSelectStartTime;

        AnalyticsManager.instance.RegisterLevelSelectionCompleted(selectedLevelId, elapsedTime);

        levelSelectTimerRunning = false;
    }
}

