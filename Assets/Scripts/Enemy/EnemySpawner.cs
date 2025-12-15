using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnInterval; 

    private Camera mainCamera;
    private bool isSpawning = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (GameManager.Instance.isLevelFinished == false && !isSpawning)
        {
            InvokeRepeating(nameof(SpawnEnemy), 0f, spawnInterval);
            isSpawning = true;
        }

        if (GameManager.Instance.isLevelFinished == true && isSpawning)
        {
            CancelInvoke(nameof(SpawnEnemy));
            isSpawning = false;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = mainCamera.ViewportToWorldPoint(new Vector3(1.1f, Random.Range(0f, 1f), 0));
        spawnPosition.z = 0f; 

        Instantiate(enemyPrefabs[Random.Range(0,enemyPrefabs.Length)], spawnPosition, Quaternion.identity); // instantiates the enemy prefab
    }
}