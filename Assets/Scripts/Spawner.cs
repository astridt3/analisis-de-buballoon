
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bubbleSpawn;
    private float spawnTime = 2f;
    private float spawnDelay = 3f;
    public GameObject spawner;

    void Start()
    {

        InvokeRepeating("SpawnSpawner", spawnTime, spawnDelay);
    }
    void Update()
    {

    }
    void SpawnSpawner()
    {
        Instantiate(bubbleSpawn, spawner.transform.position, spawner.transform.rotation);
    }
}
