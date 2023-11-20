using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour attackBehaviour, patrolBehaviour;
    [SerializeField]
    private AIDetector detector;

    private Rigidbody2D body;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
          if (detector.TargetVisible)
          {
              attackBehaviour.PerformAction(detector, body);
          }
          else
          {
              patrolBehaviour.PerformAction(detector, body);
          }
    }
}
