using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausaPanel;
    private bool juegoPausado = false;

    public void Start()
    {
        pausaPanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Pause()
    {
        pausaPanel.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }
    public void Resume()
    {
        pausaPanel.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    public void GoToMenu(string nombreEscenaMenu)
    {
        RegisterAbandonedAttempt();

        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Quit()
    {
        RegisterAbandonedAttempt();

        Application.Quit();
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
