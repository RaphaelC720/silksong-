using System.Collections;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement stuff
    private float moveInput;
    public float turtleSpeed = 5;
    private float accelerationTime = 0.1f;
    private float velocityXSmoothing = 0f;
    private float velocityYSmoothing = 0f;
    public float MaxturtleSpeed = 5;
    private float dashingPower = 15f; 
    private float dashingTime = 0.2f; 
    private float dashingCooldown = 1f;
    private bool canDash = true;
    private bool isDashing;
    Vector2 input;
    public Animator animator;
    public Rigidbody2D turtleRB;
    public bool onCooldown;
    
    public bool movementEnabled = true;
    public static PlayerMovement Instance;
    public int StuckAmount = 10;
    public int currentStuckAmount;

    public GameObject stuckPanel;
    public GameObject stuckMeter;
    void Start()
    {
        turtleRB = GetComponent<Rigidbody2D>();    
        if (Instance == null)
        {
            Instance = this;
        }
        movementEnabled = true;
    }
    void Update()
    {
        if (movementEnabled == true)
        {
            if (isDashing)
                return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            input = new Vector2(horizontal, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                FindAnyObjectByType<IconScript>().InitiateCooldown();
                StartCoroutine(Dash());
            }
        }
        if (currentStuckAmount <= 0)
        {
            stuckPanel.SetActive(false);
        }
        if (movementEnabled == false)
        {
            stuckPanel.SetActive(true);
            if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A) || 
                Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                currentStuckAmount -= 1;
                RectTransform rt = stuckMeter.GetComponent<RectTransform>();

                if (currentStuckAmount <= 0)
                {
                    stuckPanel.SetActive(false);
                    rt.localScale = new Vector3(0f, 1f, 1f);
                }
                else if (currentStuckAmount == 1)
                    rt.localScale = new Vector3(0.2f, 1f, 1f);
                else if (currentStuckAmount == 2)
                    rt.localScale = new Vector3(0.4f, 1f, 1f);
                else if (currentStuckAmount == 3)
                    rt.localScale = new Vector3(0.6f, 1f, 1f);
                else if (currentStuckAmount == 4)
                    rt.localScale = new Vector3(0.8f, 1f, 1f);


            }
            else if (currentStuckAmount == 0)
            {
                movementEnabled = true;
                Debug.Log("movementEnabled");
            }
        }
    }
    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        float targetX = input.x * turtleSpeed;
        float targetY = input.y * turtleSpeed;
        float smoothedX = Mathf.SmoothDamp(turtleRB.linearVelocity.x, targetX, ref velocityXSmoothing, accelerationTime);
        float smoothedY = Mathf.SmoothDamp(turtleRB.linearVelocity.y, targetY, ref velocityYSmoothing, accelerationTime);
        turtleRB.linearVelocity = new Vector2(smoothedX, smoothedY);
    
        if (turtleRB.linearVelocity.magnitude > MaxturtleSpeed)
        {
            turtleRB.linearVelocity = Vector2.ClampMagnitude(turtleRB.linearVelocity, MaxturtleSpeed); // This will cap the player's max turtleSpeed if exceeded.
        }
        if (turtleRB.linearVelocity.magnitude >0.5f)
            animator.SetBool("IsMoving",true);
        else
            animator.SetBool("IsMoving", false);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // save current input direction
        Vector2 dashDirection = input.normalized;
        // apply dash velocity
        turtleRB.linearVelocity = dashDirection * dashingPower;
        // wait during dash
        yield return new WaitForSeconds(dashingTime);
        // stop dash movement
        turtleRB.linearVelocity = Vector2.zero;
        isDashing = false;
        // wait for cooldown
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}
