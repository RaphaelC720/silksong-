using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int CurrentHealth;
    public int MaxHealth = 5; 
    public bool IsDead {get; private set; }
    public event Action<int> OnDamageTaken;
    public event Action OnDeath;

    public void Awake()
    {
        CurrentHealth = MaxHealth;
    }
    public void Update()
    {
        if(GameManager.Instance.isLevelFinished == true)
        {
            CurrentHealth = MaxHealth;
        }
    }
    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        CurrentHealth -= damage; 
        OnDamageTaken?.Invoke(damage);

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            IsDead = true;
            OnDeath.Invoke();
        }
    }

}