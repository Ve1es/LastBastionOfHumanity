using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public TankMovementData movementData;
    private Rigidbody2D body;
    
    private float currentSpeed = 10;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 _movement)
    {
        body.velocity = _movement * movementData.maxSpeed * Time.fixedDeltaTime;
        //body.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -_movement.x * movementData.rotationSpeed * Time.fixedDeltaTime));
    }

 
}
