using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    
    public PlayerMove playerMove;
    public PlayerTurn playerTurn;
    public GunSystem gunSystem;
    //public Turret aimTurret;
    //public TurretShootController[] turrets;

    private void Awake()
    {
        if (playerMove == null)
            playerMove = GetComponentInChildren<PlayerMove>();
        if (playerTurn == null)
            playerTurn = GetComponentInChildren<PlayerTurn>();
    }

    public void Shoot()
    {
        gunSystem.MyInput();
    }
    public void Reload()
    {
        gunSystem.Reload();
    }

    public void MoveBody(Vector2 movementVector)
    {
        playerMove.Move(movementVector);
    }

    public void TurnBody(Vector2 pointerPosition)
    {
         playerTurn.Turn(pointerPosition);

    }
}
