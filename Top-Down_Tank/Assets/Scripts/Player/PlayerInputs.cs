using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    public PlayerController playerController;

    private Controls controls;
    private Vector2 _movement = new Vector2(0, 0);
    private Rigidbody2D body;

    public UnityEvent OnShoot = new UnityEvent();
    private void Awake()
    {
        controls = new Controls();
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        Turn();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnShoot?.Invoke();
        }
    }
    public void DelayShoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        { }
        /*switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Performed");
                break;
            case InputActionPhase.Started:
                Debug.Log("Started");
                break;
            case InputActionPhase.Canceled:
                Debug.Log("Canceled");
                break;
        }*/
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            playerController.Reload();
        }
    }
    private void Move()
    {
        playerController.MoveBody(_movement);  
    }
    private void Turn()
    {
        playerController.TurnBody(GetTurretMovement());
    }

    private Vector2 GetTurretMovement()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        return Worldpos;
    }
    public void GetBodyMovement(InputAction.CallbackContext context)
    {
        _movement = context.ReadValue<Vector2>();
    }
    private void OnEnable()
    {
        controls.PlayerMap.Enable();
    }
    private void OnDisable()
    {
        controls.PlayerMap.Disable();
    }
}
