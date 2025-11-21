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


        void Start()
        {
            turtleRB = GetComponent<Rigidbody2D>();    
        }
        void Update()
        {
            if (isDashing) 
                return;

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            input = new Vector2(horizontal, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
                StartCoroutine(Dash());
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
