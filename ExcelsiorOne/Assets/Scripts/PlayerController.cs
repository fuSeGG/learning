using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float m_JumpForce = 150f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .25f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, 1)] [SerializeField] private double m_SlideSpeed = .9f;          // Amount of maxSpeed applied to slide movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

    const float k_GroundedRadius = .05f; // Radius of the overlap circle to determine if grounded
    public bool Grounded;            // Whether or not the player is grounded.
    public bool JumpClimax = false;    // Tells us when we reached jump climax, so we can change to appropriate animation.
    const float k_CeilingRadius = .05f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    private float slideFactor = 10f;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool wasCrouching = false;

    private void Awake() {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate() {
        bool wasGrounded = Grounded;
        Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++) {
            if (colliders[i].gameObject != gameObject) {
                Grounded = true;
                JumpClimax = false;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
            else if (m_JumpForce < 0 && !Grounded) {
                JumpClimax = true;
            }
        }
    }


    public void Move(float move, bool crouch, bool slide, bool jump) {
        // If crouching, check to see if the character can stand up
        /* if (!crouch) {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround)) {
                crouch = true;
            }
        }
        */

        //only control the player if grounded or airControl is turned on
        if (Grounded || m_AirControl) {

            /* If crouching
            if (crouch) {
                if (!wasCrouching) {
                    wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            } else {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (wasCrouching) {
                    wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
            */


            if (slide && slideFactor >= 5*Time.deltaTime) {
                slideFactor -= 5 * Time.deltaTime;
                // Disable one of the colliders when sliding
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else if (slide) {
                slideFactor = 0;
            }
            else {
                slideFactor = 10;
                // Enable the collider when not sliding                
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * slideFactor, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight) {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight) {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (Grounded && jump) {
            // Add a vertical force to the player.
            Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }


    private void Flip() {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}