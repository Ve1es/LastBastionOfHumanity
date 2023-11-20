using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    [SerializeField] float turretRotationSpeed = 100;
    public Transform turretParent;

    public void Turn(Vector2 _pointerPossition)
    {
        var turretDirection = (Vector3)_pointerPossition - transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;
        //var rotationStep = turretRotationSpeed * Time.deltaTime;
        turretParent.rotation = Quaternion.Euler(0, 0, desiredAngle-90);
    }
}
