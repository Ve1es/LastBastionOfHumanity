using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public TankController TC;

    private Controls controls;
    private Vector2 _movement = new Vector2(0, 0);
    private Rigidbody2D body;
    private void Awake()
    {
        controls = new Controls();
        body = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
    }
    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            TC.HandleShoot();
        }
    }
    public void DelayShoot(InputAction.CallbackContext context)
    {
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Performed");
                TC.DelayShoot();
                break;
            // if (context.performed)
            //{//}
            case InputActionPhase.Started:
                Debug.Log("Started");
                break;
            case InputActionPhase.Canceled:
                Debug.Log("Canceled");
                break;

        }
    }
   
    private void Move()
    {
        TC.HandleMoveBody(_movement);
        TC.HandleTurretMovement(GetTurretMovement());
        //Debug.Log(GetMousePositon().ToString());
        //Debug.Log(_movement.ToString());
        //body.velocity = new Vector2(_movement.x * _speed, _movement.y * _speed);
        // if (_movement.x == 0 && _movement.y == 0) { body.velocity = new Vector2(0, 0); }
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
