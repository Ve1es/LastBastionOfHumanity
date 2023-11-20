using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeBehaviour : AIBehaviour
{
    public float movementSpeed = 5f; // �������� �������� �����
    public float attackDistance = 2f; // ��������� ��� ������� �����
    public float specialAttackDistance = 15f; // ��������� ��� ����������� �����
    public float attackDamage = 10f; // ���� ��� ������� �����
    public float specialAttackDamage = 20f; // ���� ��� ����������� �����

    private GameObject player;
   // private PlayerController playerController;
    private bool isSpecialAttacking = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // ������ ������ �� ���� "Player"
       // playerController = player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackDistance)
        {
            AttackPlayer();
        }
        else if (distanceToPlayer <= specialAttackDistance && !isSpecialAttacking)
        {
            // ���� ��������� � �������� ��������� ��� ����������� �����
            StartSpecialAttack();
        }
        else
        {
            // ���� ��������� ������ �� ������, ������������ � ������
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // ����������� �������� � ������
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // ������� ����� � ����������� ������
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // �������� �� ������
       // playerController.TakeDamage(attackDamage);
    }

    private void StartSpecialAttack()
    {
        // �������� ����������� ����� � ��������� ��������
        if (!isSpecialAttacking)
        {
            isSpecialAttacking = true;
            StartCoroutine(SpecialAttack());
        }
    }

    private IEnumerator SpecialAttack()
    {
        // ����� ����� ���� �������� ��� ������ ������� ����������� �����
        // ��� ���� ������� ������ � ������
     //   playerController.TakeDamage(specialAttackDamage);

        // ���� ��������� ����� ����� ��������� ����������� ������
        yield return new WaitForSeconds(2f);

        // ��������� ����������� �����
        isSpecialAttacking = false;
    }

    /*public override void PerformAction(TankController tank, AIDetector detector)
    {
        if (TargetInFOV(tank, detector))
        {
            tank.HandleMoveBody(Vector2.zero);
            tank.HandleShoot();
        }

        tank.HandleTurretMovement(detector.Target.position);
    }
    */
    private bool TargetInFOV(TankController tank, AIDetector detector)
    {
        var direction = detector.Target.position - tank.aimTurret.transform.position;
        if (Vector2.Angle(tank.aimTurret.transform.right, direction) < attackDistance / 2)
        {
            return true;
        }
        return false;
    }

    public override void PerformAction(AIDetector detector, Rigidbody2D body)
    {
        throw new System.NotImplementedException();
    }
}