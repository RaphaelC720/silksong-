using UnityEngine;
using UnityEngine.UI;

public class ShieldSpawn : MonoBehaviour

{
    public GameObject Shield;
    public Image cooldownUI;
    public bool isShielded = false; 
    public bool isOnCooldown = false;
    private bool isSwitching = false;
    public float cooldownDuration = 1f;
    private float shieldDuration = 1f;
    private float cooldownTimer = 0f;
    private float shieldTimer;

    
    public Animator animator;

    void Start()
    {
        Shield.SetActive(false);
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && !isShielded && !isOnCooldown)
        {
            ActivateShield();
        }
        if (isShielded)
        {
            shieldTimer -= Time.deltaTime;

            if (shieldTimer <= 0.2f)
                animator.Play("ShieldWindDown");

            if (shieldTimer <= 0f)
                EndShield();
        }
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;

            if (cooldownUI != null)
                cooldownUI.fillAmount = cooldownTimer / cooldownDuration;

            if (cooldownTimer <= 0f)
                isOnCooldown = false;
        }
    }

    void ActivateShield()
    {
        isShielded = true;
        shieldTimer = shieldDuration;

        Shield.SetActive(true);
        animator.Play("Shield");
        isOnCooldown = true;
        cooldownTimer = cooldownDuration;

        if (cooldownUI != null)
            cooldownUI.fillAmount = 1f;
    }

    void EndShield()
    {
        Shield.SetActive(false);
        isShielded = false;
    }
}