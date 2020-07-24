﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latiku_controller : MonoBehaviour
{
    Animator animator;
    Rigidbody2D latikuRB;
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private float latiku_speed = 1.5f;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        latikuRB = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }




    private void FixedUpdate()
    {
                
        if (Input.GetKey("right"))
        {
            latikuRB.velocity = new Vector2(latiku_speed, 0);

        }
        else if (Input.GetKey("left"))
        {
            latikuRB.velocity = new Vector2(-latiku_speed, 0);

        }
        else
        {
            latikuRB.velocity = new Vector2(0, 0);

        }

    }

}

