
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuInicial : MonoBehaviour
{
    // Start is called before the first frame update
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void Play()
    {
        SceneManager.LoadScene(3);
    }

    public void Controles()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();

    }
}
