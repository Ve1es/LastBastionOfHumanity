using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour
{
    public TankMovementData movementData;
    private Rigidbody2D body;
    private float currentSpeed = 0;
    private float currentForewardDirection = 1;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void Move(Vector2 _movement)
    {
        //Debug.Log(_movement.ToString());
        body.velocity = (Vector2)transform.up* currentSpeed * currentForewardDirection * Time.fixedDeltaTime;
        body.MoveRotation(transform.rotation*Quaternion.Euler(0,0, -_movement.x* movementData.rotationSpeed*Time.fixedDeltaTime));
        MoveStop(_movement);
    }

    private void MoveStop(Vector2 _movement)
    {
        CalculateSpeed(_movement); ;
        if (_movement.y > 0)
        {
            if (currentForewardDirection == -1)
                currentSpeed = 0;
            currentForewardDirection = 1;
        }
        else if (_movement.y < 0)
        {
            if (currentForewardDirection == 1)
                currentSpeed = 0;
            currentForewardDirection = -1;
        }
    }
    private void CalculateSpeed(Vector2 _movement)
    {
        if(Mathf.Abs(_movement.y)>0)
        {
            currentSpeed += movementData.acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= movementData.deacceleration * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, movementData.maxSpeed);
    }
    
}
