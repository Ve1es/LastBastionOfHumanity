using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrolStaticBehaviour : AIBehaviour
{
    public float patrolDelay = 4;

    [SerializeField]
    private Vector2 randomDirection = Vector2.zero;
    [SerializeField]
    private float currentPatrolDelay;

    public override void PerformAction(AIDetector detector, Rigidbody2D body)
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        randomDirection = Random.insideUnitCircle;
    }

   /* public override void PerformAction(TankController tank, AIDetector detector)
    {
        
        float angle = Vector2.Angle(tank.aimTurret.transform.right, randomDirection);
        //Debug.Log("currentPatrolDelay " + currentPatrolDelay);
        //Debug.Log("angle "+angle);
        if (currentPatrolDelay <= 0)
        {
            randomDirection = Random.insideUnitCircle;
            currentPatrolDelay = patrolDelay;
        }
        else
        {
            if (currentPatrolDelay > 0)
            {
                tank.HandleTurretMovement((Vector2)tank.aimTurret.transform.position + randomDirection);
                currentPatrolDelay -= Time.deltaTime;
            }
            //else
                
        }
    }*/
}
