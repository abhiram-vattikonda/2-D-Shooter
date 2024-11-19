using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnBulletButtonPressed;

    private PlayerInputActions playerInputActions;

    private float fireTimer;
    private float fireRate = 0.5f;


    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        
    }

    private void Update()
    {
        if (playerInputActions.Player.Shoot.IsPressed() && fireTimer <= 0f)
        {
            OnBulletButtonPressed?.Invoke(this, new EventArgs());
            fireTimer = fireRate;
        }
        else
        {
            fireTimer -= Time.deltaTime;
        }
    }


    public Vector2 GetMovementInput()
    {
        Vector2 inputValue = playerInputActions.Player.Movement.ReadValue<Vector2>();
        return inputValue.normalized;
    }

    
}
