using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] float turretRotationSpeed=100;
    public Transform turretParent;
    
    public void TurretMove(Vector2 _pointerPossition)
    {
        var turretDirection = (Vector3)_pointerPossition-transform.position;
        var desiredAngle = Mathf.Atan2(turretDirection.y, turretDirection.x)*Mathf.Rad2Deg;
        var rotationStep = turretRotationSpeed * Time.deltaTime;
        turretParent.rotation = Quaternion.RotateTowards(turretParent.rotation, 
            Quaternion.Euler(0, 0, desiredAngle-90), rotationStep);
    }
}
