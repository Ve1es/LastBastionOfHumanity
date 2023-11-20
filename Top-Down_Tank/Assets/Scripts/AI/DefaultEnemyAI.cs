using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField]
   // private AttackBehaviour attackBehaviour;
    private PatrolBehaviour patrolBehaviour;

    //[SerializeField]
    //private TankController tank;
   // [SerializeField]
   // private AIDetector detector;

    private void Awake()
    {
       // detector = GetComponentInChildren<AIDetector>();
      //  tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
      /*  if (attackBehaviour.AttackDistance)
        {
            attackBehaviour.PerformAction(player);
        }
        else
        {
            patrolBehaviour.PerformAction(player);
        }*/
    }
}
