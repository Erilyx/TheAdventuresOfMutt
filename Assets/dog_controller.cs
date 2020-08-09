using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dog_controller : MonoBehaviour
{

    Animator animator;
    Rigidbody2D dogRB;
    SpriteRenderer spriteRenderer;

    //private float previousTime = 0;

    [SerializeField]
    public float moveTime = 0.8f;

    bool isGrounded;

    [SerializeField]
    private float dog_speed = 1.5f;

    [SerializeField]
    private float dog_jump = 5;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    Transform groundCheckR;

    [SerializeField]
    Transform groundCheckL;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        dogRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        
        if((Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckL.position, 1 << LayerMask.NameToLayer("Ground"))) ||
            (Physics2D.Linecast(transform.position, groundCheckR.position, 1 << LayerMask.NameToLayer("Ground"))))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
            animator.Play("dog_jump");
        }

        if (Input.GetKey("d"))
        {
            dogRB.velocity = new Vector2(dog_speed, dogRB.velocity.y);
            
            if(isGrounded)
                animator.Play("dog_run");
            spriteRenderer.flipX = false;
        }
        else if (Input.GetKey("a"))
        {
            dogRB.velocity = new Vector2(-dog_speed, dogRB.velocity.y);
            
            if (isGrounded)
                animator.Play("dog_run");
            spriteRenderer.flipX = true;
        }
        else
        {
            dogRB.velocity = new Vector2(0, dogRB.velocity.y);

            if (isGrounded)
                animator.Play("dog_idle");
        }

        if((Input.GetKey("space") || (Input.GetKey("w"))) && (isGrounded))
        {
            dogRB.velocity = new Vector2(dogRB.velocity.x, dog_jump);
            animator.Play("dog_jump");
        }
    }

}

    