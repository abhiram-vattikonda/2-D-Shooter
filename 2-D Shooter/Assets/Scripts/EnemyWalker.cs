using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    private float speed = 400f;
    private float rotationSpeed = 0.06f;
    private float health = 30f;
    private float damageAmount = 10f;


    private Rigidbody2D rb;
    [SerializeField] private Transform tip;



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        RotateTowardPlayer();
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
            Destroy(this.gameObject);
        }
    }
}