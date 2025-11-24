using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    //Tools
    public Rigidbody2D RB;
    public float knockbackForce = 3;
    public void Knockback(Vector2 direction)
    {
        RB.AddForce(direction.normalized * knockbackForce, ForceMode2D.Impulse); //when hit apply force to knock player back.
        Debug.Log(direction);
    }
}
