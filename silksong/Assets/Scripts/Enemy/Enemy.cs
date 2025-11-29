using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float speed = 4f; // speed of enemy
    

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // speed formula for only moving from right to left
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Shield") 
        {
            speed *= -3f;
        }
       
       
        if (other.gameObject.TryGetComponent(out PlayerKnockback playerKnockback))
        {
            playerKnockback.Knockback(playerKnockback.transform.position - transform.position); //Knocks the player back away from enemy
        }


        if(other.gameObject.TryGetComponent(out Health health))
        {
            health.TakeDamage(1);
            Destroy(gameObject);
        }    

    }
}