using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMeleeBehaviour : AIBehaviour
{
    public float movementSpeed = 5f; // Скорость движения врага
    public float attackDistance = 2f; // Дистанция для ближней атаки
    public float specialAttackDistance = 15f; // Дистанция для специальной атаки
    public float attackDamage = 10f; // Урон при ближней атаке
    public float specialAttackDamage = 20f; // Урон при специальной атаке

    private GameObject player;
   // private PlayerController playerController;
    private bool isSpecialAttacking = false;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // Найдем игрока по тегу "Player"
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
            // Враг находится в пределах дистанции для специальной атаки
            StartSpecialAttack();
        }
        else
        {
            // Враг находится далеко от игрока, перемещаемся к игроку
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        // Направление движения к игроку
        Vector3 direction = (player.transform.position - transform.position).normalized;

        // Двигаем врага в направлении игрока
        transform.Translate(direction * movementSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        // Нападаем на игрока
       // playerController.TakeDamage(attackDamage);
    }

    private void StartSpecialAttack()
    {
        // Начинаем специальную атаку и запускаем корутину
        if (!isSpecialAttacking)
        {
            isSpecialAttacking = true;
            StartCoroutine(SpecialAttack());
        }
    }

    private IEnumerator SpecialAttack()
    {
        // Здесь может быть анимация или другие эффекты специальной атаки
        // При этом ударяем игрока с уроном
     //   playerController.TakeDamage(specialAttackDamage);

        // Ждем некоторое время перед повторной специальной атакой
        yield return new WaitForSeconds(2f);

        // Завершаем специальную атаку
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