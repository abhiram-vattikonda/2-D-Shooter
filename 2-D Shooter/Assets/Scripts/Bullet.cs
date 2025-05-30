using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private static float speed = 500.0f;
    private static float damage = 15.0f;
    public static float currentDamage  =15.0f;

    public static float instanceDamage;
        
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {
        currentDamage = damage;
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.right * speed * Time.deltaTime;
    }

    private void Update()
    {
        CheckingIfOnScreen();   
    }

    private void CheckingIfOnScreen()
    {
        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        if (pos.x > (Screen.safeArea.xMax) || pos.x < (Screen.safeArea.xMin))
        {
            Destroy(this.gameObject);
        }
        if (pos.y > (Screen.safeArea.yMax) || pos.y < (Screen.safeArea.yMin))
        {
            Destroy(this.gameObject);
        }
    
    }

    public void SetDamage(float damage)
    {
        instanceDamage = damage; // Assign damage to this instance
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         Destroy(this.gameObject);
    }
}
