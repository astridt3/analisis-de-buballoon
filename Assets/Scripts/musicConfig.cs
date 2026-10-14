using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicConfig : MonoBehaviour
{
    public static musicConfig instance;
    private void Awake()
    {
            
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
               
                Destroy(gameObject);
            }
    }
    
    void Update()
    {
        
    }
}
