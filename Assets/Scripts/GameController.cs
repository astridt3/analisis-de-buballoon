
using UnityEngine;


public class GameController : MonoBehaviour
{
    public static GameController Instance;
    void Awake()
    {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
    }
}
