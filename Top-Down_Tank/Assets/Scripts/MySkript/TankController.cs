using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public Turret aimTurret;
    public TurretShootController[] turrets;

    private void Awake()
    {
        if (tankMover == null)
            tankMover = GetComponentInChildren<TankMover>();
        if (aimTurret == null)
            aimTurret = GetComponentInChildren<Turret>();
        if (turrets == null || turrets.Length == 0)
        {
            turrets = GetComponentsInChildren<TurretShootController>();
        }
    }

    public void HandleShoot()
    {
        foreach (var turret in turrets)
        {
            turret.Shoot();
        }
    }
    public void DelayShoot()
    {
        foreach (var turret in turrets)
        {
            turret.DelayShoot();
        }

    }

    public void HandleMoveBody(Vector2 movementVector)
    {
        tankMover.Move(movementVector);
    }

    public void HandleTurretMovement(Vector2 pointerPosition)
    {
        aimTurret.TurretMove(pointerPosition);

    }

}
