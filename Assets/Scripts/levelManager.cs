
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelManager : MonoBehaviour
{
    private bool isPaused = false;

   public void restart()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void mainmenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void salir()
    {
        Application.Quit(); 
    }

    public void pause()
    {
        if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            isPaused = true;
        }

    }

    private void Update()
    {
       if(SceneManager.GetActiveScene().name != "Main Menu" || SceneManager.GetActiveScene().name != "Controls")
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                pause();
            }
        }
    }
}