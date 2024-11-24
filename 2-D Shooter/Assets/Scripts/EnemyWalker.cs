using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private float speed = 200f;
    private float rotationSpeed = 0.06f;
    private float health = 30f;
    public float damage = 10f;


    private Rigidbody2D rb;
    [SerializeField] private Transform tip;
    [SerializeField] private Experience exp;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        RotateTowardPlayer();
        if (health <= 0)
        {
            Instantiate<Experience>(exp, transform.position + new Vector3(0,0,0.1f), Quaternion.identity);
            Destroy(this.gameObject);
        }

    }
    void FixedUpdate()
    {
        rb.velocity = (tip.position - transform.position) * speed * Time.deltaTime;
    }


    private void RotateTowardPlayer()
    {
        Vector3 pos = Player.instance.transform.position - transform.position;

        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)), rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Bullet>(out Bullet bullet))
        {
            health -= Bullet.damage;
        }
    }

    public void PlayerKnockBack()
    {
        int knockback = 100;
        Vector2 force = (transform.position - Player.instance.transform.position).normalized * knockback;
        rb.AddForce(force, ForceMode2D.Impulse);
    }
}