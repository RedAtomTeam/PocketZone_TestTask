using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime; 
    private Rigidbody2D rb;
    public int damage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Vector3 forwardDirection = transform.forward;
        Destroy(gameObject, lifeTime); 
    }

    private void Update()
    {
        Vector3 forwardDirection = transform.forward;
        rb.velocity = forwardDirection * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(damage); 
            }
        }
        Destroy(gameObject); 
    }
}
