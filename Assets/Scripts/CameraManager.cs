
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject mainCamera;
  


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player != null)
        {
            mainCamera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, mainCamera.transform.position.z);
        }
    }
}