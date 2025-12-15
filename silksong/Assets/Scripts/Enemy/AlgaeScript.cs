using UnityEngine;

public class AlgaeScript : MonoBehaviour
{
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.Instance.movementEnabled = false;
            PlayerMovement.Instance.currentStuckAmount = PlayerMovement.Instance.StuckAmount;
            Debug.Log("Stuck");
        }
    }
}
