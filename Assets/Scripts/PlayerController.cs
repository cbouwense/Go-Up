using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : PhysicsObject
{
    [SerializeField] private GameObject egg;
    public int eggsOut;

    GameControls gameControls;

    private void OnEnable()
    {
        rb2d = GetComponent<Rigidbody2D>();
        eggsOut = 0;

        gameControls = new GameControls();
        gameControls.Gameplay.Enable();
    }

    protected override void ComputeVelocity()
    {

        // Horizontal Input
        if (stats.getMoveable())
        {
            velocityX = gameControls.Gameplay.Movement.ReadValue<float>(); //Input.GetAxisRaw("Horizontal");
            if (velocityX > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (velocityX < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

            // If we haven't spawned any eggs yet, move about freely
            if (/*stats.getEggCurr() >= stats.getEggMax()*/eggsOut == 0 || grounded)
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
        //if (Input.GetButtonDown("Jump"))
        if (gameControls.Gameplay.Jump.WasPressedThisFrame())
        {
            // If we're on the ground, jump normally
            if (grounded)
            {
                velocity.y = stats.jumpVelocity;
                sm.PlaySound("jump_sound");
            }
            // If we are in the air and have more eggs left, spawn an egg
            else if (stats.getEggCurr() > 0)
            {
                if (groundNormal == Vector2.zero)
                {
                    groundNormal = Vector2.up;
                }
                // Spawn an egg
                Instantiate(egg, new Vector2(transform.position.x, transform.position.y-1.5f), new Quaternion());
                // Decrement egg counter
                stats.setEggCurr(stats.getEggCurr() - 1);
                // Dampen y movement
                velocity.y = stats.eggJumpVelocity;
                // Play spin animation
                anim.SetBool("layEgg", true);
                sm.PlaySound("jump_sound");
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