using UnityEngine;

public class ShieldSpawn : MonoBehaviour

{
    public GameObject Shield; // referencing shield
    public int ShieldTimer = 300; // time allowed to have shield up
    public bool isShielded = false; // making shield accessible

    public Sprite spriteA; // Default sprite
    public Sprite spriteB; // Sprite to show after spacebar
    public float displayTime = 3f; // Time to show Sprite B

   
    private bool isSwitching = false;
    private float timer = 0f;
    public Animator animator;

    void Start()
    {
        Shield.SetActive(false); // shield is off on start of game

        
      
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isShielded == false) // shield goes on w/ Space input
        {
            isShielded = true;
        
            isSwitching = true;
            animator.Play("Shield");
        }

        if (ShieldTimer > 0 && isShielded == true) //shield initiation starts timer
        {
            Shield.SetActive(true);
            ShieldTimer--;
            
            isSwitching = true;

        }

        if (ShieldTimer <= 0) // time runs out
        {
            Shield.SetActive(false); // shield goes inactive
            isShielded = false;
            ShieldTimer = 300; // timer set again for 300

            
            isSwitching = false;
            animator.Play("ShieldWineDown");

        }
    }
}