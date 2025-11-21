using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Health ObjectHealth; 
    public GameObject heartPrefab;
    private List<GameObject> spawnedHearts = new List<GameObject>();
    private void Start()
    {
        CreateHearts();
        ObjectHealth.OnDamageTaken += UpdateHearts;
    }
    private void OnDestroy()
    {
        ObjectHealth.OnDamageTaken -= UpdateHearts;
    }
    private void UpdateHearts(int damage) 
    {
        for (int i = 0;i < spawnedHearts.Count;i++)
        {
            Destroy(spawnedHearts[i]);
        }
        CreateHearts();

    }
    private void CreateHearts()
    {
        for (int i = 0; i < ObjectHealth.CurrentHealth; i++)
        {
            GameObject spawnedHeart = Instantiate(heartPrefab, transform);
            spawnedHearts.Add(spawnedHeart);
        }
    }
}
