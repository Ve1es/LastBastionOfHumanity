using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehaviour : AIBehaviour
{
    public AIMove aiMove;
    [SerializeField]
    private float _movement = 5f;

    public override void PerformAction(AIDetector detector, Rigidbody2D body)
    {
        aiMove.MoveToTarget(body, detector.Target, _movement);

        aiMove.RotateToTarget(body, detector.Target);
    }
}
