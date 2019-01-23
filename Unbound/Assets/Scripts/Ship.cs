using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D ship;
    const int MovePerSecond = 2;
    const int ThrustForce = 2;
    Vector2 thrustDirection = new Vector2();


    public void Start()
    {
        ship = GetComponent<Rigidbody2D>();
        thrustDirection.Set(1, 0);
    }

    private void FixedUpdate()
    {
        float ThrustInput = Input.GetAxis("Thrust");
        float HorizontalInput = Input.GetAxis("Horizontal");

        

        if (ThrustInput > 0)
        {
            Vector2 n = thrustDirection * ThrustForce;
            ship.AddForce(n);
        }

        /*
        if (HorizontalInput != 0)
        {
            Vector2 position = transform.position;
            position.x += HorizontalInput * MovePerSecond * Time.deltaTime;
            transform.position = position;

            if (HorizontalInput < 0) animator.SetBool("RollLeft", true);
            else if (HorizontalInput > 0) animator.SetBool("RollRight", true);
        }
        else if (HorizontalInput == 0)
        {
            animator.SetBool("RollLeft", false);
            animator.SetBool("RollRight", false);
        }        
        }*/
    }
}


