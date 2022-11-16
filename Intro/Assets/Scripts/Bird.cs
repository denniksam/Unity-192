﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public static float PipeShift = 2;   // розмах випадкових відхилень труби

    [SerializeField]
    private float JumpMagnitude = 10f;

    private Rigidbody2D Rigidbody2D;
    private Vector2 jumpForce;
    private float holdTime;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        jumpForce = Vector2.up * JumpMagnitude;
        holdTime = 0;
    }

    void Update()
    { 
        float jump = Input.GetAxis("Jump");                  // Continual
        jump *= Time.deltaTime * 100;
        Rigidbody2D.AddForce(jumpForce * jump);


        // jump = Input.GetKeyDown(KeyCode.Space) ? 20 : 0;   // Discrete
        // jump *= Time.deltaTime * 100;
        // Rigidbody2D.AddForce(jumpForce * jump);


        // jump = 1.5f;                                       // Mixed
        // if (Input.GetKey(KeyCode.Space))
        // {
        //     if(holdTime == 0) holdTime = 1;
        //     if(holdTime > 0) holdTime -= Time.deltaTime;
        // }
        // else holdTime = 0;
        // jump *= Time.deltaTime * 100;  // Корекція на швидкість кадрів
        // if( holdTime > 0) Rigidbody2D.AddForce(jumpForce * jump);

        //if (jump > 0) Debug.Log(jump);
    }
}