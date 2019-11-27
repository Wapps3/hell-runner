﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    [SerializeField]
    private float speed = 8;
    [SerializeField]
    private float acceleration = 30;
    [SerializeField]
    private float jumpHeight = 12;
    [SerializeField]
    private float gravity = 20;

    [SerializeField]
    private float currentSpeed = 1.5f;
    [SerializeField]
    private float targetSpeed = 1.5f;

    private Vector2 amountToMove;

    private PlayerPhysics playerPhysics;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        playerPhysics = GetComponent<PlayerPhysics>();
    }

    private float IncrementTowards(float n, float target, float accel)
    {
        if (n == target)
            return n;
        else
        {
            float dir = Mathf.Sign(target - n);  //must n be increased or decrease to get closer to target
            n += accel * Time.deltaTime * dir;
            return (dir == Mathf.Sign(target - n)) ? n : target;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (playerPhysics.movementStop)
        {
            targetSpeed = 0;
            currentSpeed = 0;
        }

       
        targetSpeed = Random.Range(-1.0f,1.0f) * speed;
        currentSpeed = IncrementTowards(currentSpeed, targetSpeed, acceleration);

        if (playerPhysics.grounded)
        {
            amountToMove.y = 0;
        }


        amountToMove.x = currentSpeed;
        amountToMove.y -= gravity * Time.deltaTime;
        playerPhysics.Move(amountToMove * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));

        if (currentSpeed < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }

        if (currentSpeed > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }


    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            c.GetComponent<Personnage>().Hit();
        }
    }

}
