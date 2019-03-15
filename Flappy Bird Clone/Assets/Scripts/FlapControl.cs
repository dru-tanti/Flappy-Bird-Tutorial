﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlapControl : MonoBehaviour
{
    [Tooltip("The vertical force by which the player will be pushed")]
    public float force = 10f;

    [Tooltip("The rotation multiplyer to make turning more accurate")]
    public float rotationMultiplier = 5f;

    [Tooltip("The minimum angle the bird can turn")]
    public float minAngle = -90f;

    [Tooltip("The maximum angle the bird can turn")]
    public float maxAngle = 45f;

    // Store the RigidBody2D component in memory for easier access.
    private Rigidbody2D _rigidbody;

    // Loading all the references when the script is Awake.
    private void Awake() 
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        float angle = Mathf.Clamp(_rigidbody.velocity.y * rotationMultiplier, minAngle, maxAngle);
        _rigidbody.MoveRotation(angle);
    }

    // Handle all input control on Update for snappier responses.
    private void Update() 
    {
        if(Input.GetButtonDown("Jump"))
        {
            Flap();
        }    
    }

    // Causes the player to jump
    public void Flap()
    {
        /*
            We cannot change the velocity directly. but we can replace it with a Vector.
            First we create a copy.
        */
        Vector2 v = _rigidbody.velocity;

        // Change the sped on the Y Axis only.
        v.y = force;

        // Write the vector back to the rigic body
        _rigidbody.velocity = v;
    }
}
