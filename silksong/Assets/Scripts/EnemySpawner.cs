using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval = 1.5f; // amt of time it takes for enemy to spawn 

    private Camera mainCamera;
    private float spawnY;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval); // setting the random spawner
    }
    private void Update()
    {
        if (GameManager.Instance.isLevelFinished == true)
        {
            CancelInvoke(nameof(SpawnEnemy));
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0f, 1f), 0));
        spawnPosition.z = 0f; // creates the spawning range for the random spawner

        Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], spawnPosition, Quaternion.identity); // instantiates the enemy prefab
    }
}