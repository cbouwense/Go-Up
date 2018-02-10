using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{

    public int jumpsMax = 2;
    public int jumpsLeft = 0;
    private bool forceAdded = false;
    private bool crouching = false;
    private float knockbackTimerMax = 0.5f;
    private float knockbackTimerRemaining = 0.0f;
    [SerializeField] private GameObject egg;
    public bool eggOut = false;
    
    protected override void Start()
    {
        base.Start();
        jumpsLeft = jumpsMax;
    }

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    protected override void ComputeVelocity()
    {

        // Horizontal Input
        if (stats.getMoveable())
        {
            velocityX = Input.GetAxisRaw("Horizontal");
            // If we haven't spawned any eggs yet, move about freely
            if (stats.getEggCurr() == stats.getEggMax())
            {
                velocityX *= stats.getCurrentSpeed();
            }
            // If we have spawned eggs, restrict movement
            else
            {
                velocityX *= stats.eggHorizontalSpeed;
            }
        }

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            // If we're on the ground, jump normally
            if (grounded)
            {
                velocity.y = stats.jumpVelocity; 
            }
            // If we are in the air and have more eggs left, spawn an egg
            else if (stats.getEggCurr() > 0)
            {
                // Spawn an egg
                Instantiate(egg, new Vector2(transform.position.x, transform.position.y-1.5f), new Quaternion());
                // Decrement egg counter
                stats.setEggCurr(stats.getEggCurr() - 1);
                // Dampen y movement
                velocity.y = stats.eggJumpVelocity;
            }
        }

    }

    protected override void Update()
    {
        base.Update();
    }

    public void MyAddForce(Vector2 force)
    {
        velocityX += force.x;
        velocity.y = force.y;
    }

}