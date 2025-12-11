using UnityEngine;
using UnityEngine.UI;

public class IconScript : MonoBehaviour
{
    public Image darkOverlay;
    public float Cooldown;
    public float CurrentCooldown = 1f;
    public bool onCooldown;
    void Start()
    {
        
    }

    void Update()
    {
        if (onCooldown)
        {
            CurrentCooldown -= Time.deltaTime;
            darkOverlay.fillAmount = CurrentCooldown / Cooldown;   
            if (CurrentCooldown <= 0)
            {
                onCooldown = false;
                darkOverlay.fillAmount = 0;
            }
        }
    }

    public void InitiateCooldown()
    {
        onCooldown = true;
        CurrentCooldown = Cooldown;
        darkOverlay.fillAmount = 1;
    }
}
