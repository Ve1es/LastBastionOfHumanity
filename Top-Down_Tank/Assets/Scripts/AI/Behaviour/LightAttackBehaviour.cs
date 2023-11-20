using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttackBehaviour : AIBehaviour
{
    [SerializeField]
    private Transform leftHand;
    [SerializeField]
    private Transform rightHand;
    public AIMove aiMove;
    [SerializeField]
    private float attackRange;
    [SerializeField]
    private float chargingBustTime;
    [SerializeField]
    private bool canBust=true;
    [SerializeField]
    private float attackTime;
    [SerializeField]
    private float refreshAttackTime;
    [SerializeField]
    private float _movement = 0f;
    private float distanceToTarget;
    private bool canAttack=true;


    private void Start()
    {
        Debug.Log("Start");
        if (canBust)
        {
            StartCoroutine(ChargingBust(chargingBustTime));
        }
    }
    public override void PerformAction(AIDetector detector, Rigidbody2D body)
    {
        distanceToTarget = Vector2.Distance(transform.position, detector.Target.position);
        
        
        if (distanceToTarget < attackRange && canAttack)
        {
            _movement = 0f;
            StartCoroutine(Attack(8));
            canAttack = false;
        }
        if (!canAttack) { 
            MoveToTarget(detector, body);
        }
    }
    private IEnumerator ChargingBust(float time)
    {
        yield return new WaitForSeconds(time);
        _movement = 10f;
    }
    private IEnumerator Attack(float count)
    {
        yield return new WaitForSeconds(attackTime);
        leftHand.Rotate(0f, 0f, -10f);
        rightHand.Rotate(0f, 0f, 10f);
        if (count > 0)
        {
            Debug.Log("CallAttack");
            StartCoroutine(Attack(count -1));
        }
        else
        {
            StartCoroutine(RefreshAttack(refreshAttackTime));
        }
    }
    private IEnumerator RefreshAttack(float count) {
        yield return new WaitForSeconds(attackTime);
        leftHand.Rotate(0f, 0f, 10f);
        rightHand.Rotate(0f, 0f, -10f);
        if (count > 0)
        {
            StartCoroutine(RefreshAttack(count - 1));
        }
        else
        {
            canAttack = true;
            _movement = 10;
        }
    }
    private void MoveToTarget(AIDetector detector, Rigidbody2D body)
    {
        Debug.Log(_movement);
        aiMove.MoveToTarget(body, detector.Target, _movement);
        aiMove.RotateToTarget(body, detector.Target);
    }


}
