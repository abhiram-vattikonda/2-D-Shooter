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
    [SerializeField] public HealthBar healthBar;
    [SerializeField] private GameObject tryAgainMenu;


    private float playerSpeed = 5.0f;
    public float currentPlayerSpeed;
    private float maxHealth = 100f;
    public float currentMaxHealth;
    public float health;


    private void Awake()
    {
        if (instance != null)
            Debug.LogError("There is more than one player instance");
        instance = this;
    }

    private void Start()
    {
        gameInput.OnBulletButtonPressed += Player_OnBulletButtonPressed;
        healthBar.SetFullHealth(maxHealth);
        health = maxHealth;
        currentMaxHealth = maxHealth;
        currentPlayerSpeed = playerSpeed;
        transform.localScale = Vector3.one;
    }

    private void Player_OnBulletButtonPressed(object sender, EventArgs e)
    {
        Transform bulletInstance = Instantiate(bulletPrefab, bulletSpawnPostion.position, transform.rotation);
        bulletInstance.GetComponent<Bullet>().SetDamage(Bullet.currentDamage);
        Debug.Log("Bullet is fired at current damage " + Bullet.currentDamage);
        Debug.Log("Bullet is fired at instance damage " + Bullet.instanceDamage);
    }

    private void Update()
    {
        PlayerMovement();
        PlayerShootDirection();

        if (health <= 0)
        {
            PauseMenu.Pause();
            tryAgainMenu.SetActive(true);
        }

    }


    private void PlayerMovement()
    {
        Vector2 inputVector = gameInput.GetMovementInput();

        transform.position += new Vector3(inputVector.x * Time.deltaTime * currentPlayerSpeed, inputVector.y * Time.deltaTime * currentPlayerSpeed, 0);
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
        if (collision.collider.TryGetComponent<EnemyWalker>(out EnemyWalker walker))
        {
            health -= walker.damage;
            walker.PlayerKnockBack(); // Should work but not working
            healthBar.UpdateHealth(health);
        }

    }
}

