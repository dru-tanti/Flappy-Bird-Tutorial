using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroller : MonoBehaviour
{
    [Tooltip("The speed the scene will move at.")]
    public float speed = 15f;

    // Move the camera consistently to the right.
    private void Update() 
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);    
    }
}
