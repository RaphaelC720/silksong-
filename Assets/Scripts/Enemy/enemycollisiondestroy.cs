using UnityEngine;

public class EnemyCollisionDestroy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && collision.gameObject != gameObject) // if enemy contacts other enemy tag
        {
            Destroy(collision.gameObject); //remove it from scene
            Destroy(gameObject);
        }
    }
}