using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newTankMovementData", menuName = "Data/TankData")]
public class TankMovementData : ScriptableObject
{
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    public float acceleration = 70;
    public float deacceleration = 50;
}
