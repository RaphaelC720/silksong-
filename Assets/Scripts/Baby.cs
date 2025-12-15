using UnityEngine;

public class Baby : MonoBehaviour //Baby turtle will be alive!
{
    // Tools needed for baby to move and have animations.
    public Animator animator;
    public Sprite IdleSprite;
    public SpriteRenderer SpriteRenderer;
    public bool Idle;
    public Vector2 MoveDirection;
    private void Start()
    {
        if(Idle) //when idle stay still
        {
            animator.enabled = false;
            SpriteRenderer.sprite= IdleSprite;

        }
    }
    private void Update() // if not idle then babay should move.
    {
        if(!Idle)
        {
            transform.Translate(MoveDirection*Time.deltaTime,Space.World);
        }
    }
}
