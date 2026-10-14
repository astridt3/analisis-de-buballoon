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

    public void Start()
    {
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
        MedalManager.instance.ResetCoins();
        SceneManager.LoadScene("Level 1");
    }
    public void GoToMenu()
    {
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
}

