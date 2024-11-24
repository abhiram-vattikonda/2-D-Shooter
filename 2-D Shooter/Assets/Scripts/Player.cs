using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using Unity.VisualScripting.InputSystem;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player instance { get; private set; }


    [SerializeField] private Transform bulletSpawnPostion;
    [SerializeField] private Transform bulletPrefab;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private HealthBar healthBar;


    public float playerSpeed = 5.0f;
    private float maxHealth = 100f;
    private float health;


    private void Awake()
    {
        if (instance != null)
            Debug.LogError("There is more than one player instance");
        instance = this;
    }

    private void Start()
    {
        gameInput.OnBulletButtonPressed += Player_OnBulletButtonPressed;
        healthBar.SetMaxHealth(maxHealth);
        health = maxHealth;
    }

    private void Player_OnBulletButtonPressed(object sender, EventArgs e)
    {
        Transform bulletInstance = Instantiate(bulletPrefab, bulletSpawnPostion.position, transform.rotation);
    }

    private void Update()
    {
        PlayerMovement();
        PlayerShootDirection();

        if (health <= 0)
        {
            Destroy(Player.instance);
        }

    }

    private void PlayerMovement()
    {
        Vector2 inputVector = gameInput.GetMovementInput();

        transform.position += new Vector3(inputVector.x * Time.deltaTime * playerSpeed, inputVector.y * Time.deltaTime * playerSpeed, 0);
    }

    private void PlayerShootDirection()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 lookPos = Camera.main.ScreenToWorldPoint(mousePosition);
        lookPos -= transform.position;

        float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle, new Vector3(0, 0, 1));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.collider.TryGetComponent<EnemyWalker>(out EnemyWalker walker))
        {
            health -= walker.damage;
            walker.PlayerKnockBack(); // Should work but not working
            healthBar.UpdateHealth(health);
        }

    }
}

