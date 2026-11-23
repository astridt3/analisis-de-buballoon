
using UnityEngine;
using UnityEngine.SceneManagement;


public class levelManager : MonoBehaviour
{
    private bool isPaused = false;

    public void restart()
    {
        AnalyticsManager.instance.ResetAttemptData();
        SceneManager.LoadScene("Level 1");
    }

    public void mainmenu()
    {
        RegisterAbandonedAttempt();

        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void salir()
    {
        RegisterAbandonedAttempt();

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

    private void RegisterAbandonedAttempt()
    {
        CharacterBehaviour character = FindObjectOfType<CharacterBehaviour>();

        if (character == null || character.healthManager == null)
            return;

        if (AnalyticsManager.instance == null)
            return;

        AnalyticsManager.instance.EndLevelAttempt("abandoned", character.transform.position, character.GetCurrentSectionId(), Mathf.RoundToInt(character.healthManager.currentHealth));
    }
}