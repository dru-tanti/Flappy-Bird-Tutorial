﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    // A Reference to the box collider on this object.
    private BoxCollider2D _collider;
    
    // How much space this object will move to the right after it goes out of view.
    private float _width;
    
    // How many ground sprites exist in the scene.
    private int _groundCount;

    private void Awake() 
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    // Use this after the scene has loaded all of it's objects
    private void Start() 
    {
        // We'll check the width of this object to see how far we should push forward.
        _width = _collider.bounds.size.x;

        // Find out how many other ground objects there are.
        _groundCount = GameObject.FindGameObjectsWithTag("Ground").Length;
    }

    // When the camera can't see this sprite anymore, we'll move it forward.
    private void OnBecameInvisible() 
    {
        transform.Translate(Vector2.right * _width * _groundCount);
    }
}
