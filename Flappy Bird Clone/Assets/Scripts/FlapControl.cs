﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FlapControl : MonoBehaviour
{
    [Tooltip("The vertical force by which the player will be pushed.")]
    public float force = 10f;

    [Tooltip("The rotation multiplier, to make turning more accurate.")]
    public float rotationMultiplier = 5f;

    [Tooltip("The minimum angle for this bird to turn.")]
    public float minAngle = -90f;

    [Tooltip("The maximum angle for this bird to turn.")]
    public float maxAngle = 45f;

    // Store the Rigidbody2D component in memory for easier access.
    private Rigidbody2D _rigidbody;

    // A reference to the score manager on this scene.
    private ScoreManager _scoreManager;

    // Loading all the references when the script is Awake.
    private void Awake()
    {
        // Set the rigidbody to static sot hte bird will not move right away.
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.bodyType = RigidbodyType2D.Static;

        // look for the score manager on the same scene.
        _scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Physics should be allocated into FixedUpdate.
    private void FixedUpdate()
    {
        // If the rigid body is static, we'll stop trying to rotate it.
        if (_rigidbody.bodyType != RigidbodyType2D.Dynamic) return;
        float angle = Mathf.Clamp(_rigidbody.velocity.y * rotationMultiplier, minAngle, maxAngle);
        _rigidbody.MoveRotation(angle);
    }

    // When the bird collides with anything, it's game over.
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameManager.current.StopGame();
    }

    // This method will fire when the bird/player touches
    // a collider with the trigger option enabled.
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Score")
        {
            _scoreManager.AddScore();
        }
    }

    // Handle all input control on Update for snappier responses.
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (GameManager.state.Equals(GameState.Game))
            {
                Flap();
            } else if (GameManager.state.Equals(GameState.TitleScreen))
            {
                GameManager.current.StartGame();
            }
        }
    }

    // Activate the player's physics
    public void Activate()
    {
        _rigidbody.bodyType = RigidbodyType2D.Dynamic;
        Flap();
    }

    // Causes the player to "jump".
    public void Flap()
    {
        // We cannot change the velocity directly, but we can replace it
        // as a vector. First, we create a copy.
        Vector2 v = _rigidbody.velocity;

        // Change the speed on the Y axis only.
        v.y = force;

        // Write the vector back to the rigidbody.
        _rigidbody.velocity = v;
    }
}
