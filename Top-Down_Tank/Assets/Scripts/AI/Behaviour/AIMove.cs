using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMove : MonoBehaviour
{
    public void MoveToTarget(Rigidbody2D body, Transform target, float _movement)
    {
        body.velocity = (target.position - transform.position).normalized * _movement;
    }
    public void RotateToTarget(Rigidbody2D body, Transform target)
    {
        var bodyDirection = target.position - transform.position;
        var desiredAngle = Mathf.Atan2(bodyDirection.y, bodyDirection.x) * Mathf.Rad2Deg;
        body.transform.rotation = Quaternion.Euler(0, 0, desiredAngle - 90);
    }
}
