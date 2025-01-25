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
    private float firerate = 0.6f;
    [SerializeField] public static float currentFirerate;


    private void Start()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        currentFirerate = firerate;
        
    }

    private void Update()
    {
        if (playerInputActions.Player.Shoot.IsPressed() && fireTimer <= 0f)
        {
            OnBulletButtonPressed?.Invoke(this, new EventArgs());
            fireTimer = currentFirerate;
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

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }

}
