using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D ship;
    const int MovePerSecond = 2;
    const int ThrustForce = 2;
    Vector3 shipDirection = new Vector3();
    float n;

    public void Start()
    {
        ship = GetComponent<Rigidbody2D>();
        shipDirection.Set(0, 0, ship.rotation);
    }

    private void FixedUpdate()
    {
        float ThrustInput = Input.GetAxis("Thrust");
        float HorizontalInput = Input.GetAxis("Horizontal");
        ship.rotation -= HorizontalInput *100* Time.deltaTime;
        
        //ship.MoveRotation(HorizontalInput*100*Time.deltaTime);

        

        if (ThrustInput > 0)
        {
            Vector2 Accelerate = shipDirection * ThrustForce;
            ship.AddForce(Accelerate);
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


