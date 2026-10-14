
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controles : MonoBehaviour
{
    // Start is called before the first frame update
    public void back()
    {
        SceneManager.LoadScene(0);
    }
}
