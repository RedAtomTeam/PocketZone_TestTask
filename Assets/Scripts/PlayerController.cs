using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] FixedJoystick joystick;
    [SerializeField] Rigidbody2D rgb;
    [SerializeField] Animator animator;
    [SerializeField] HealthBarSystem healthbar;


    public int healthPoints;
    public int healthPointsMax;
    [SerializeField] float speed;

    void Update()
    {
        Move();

        if (healthPoints <= 0)
        {
            Dead();
        } 
    }

    void Move()
    {
        rgb.velocity = joystick.Direction * speed;

        if (rgb.velocity.y != 0 || rgb.velocity.x != 0)
        {
            animator.SetBool("IsRun", true);
        }
        else
        {
            animator.SetBool("IsRun", false);
        }

        if (rgb.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-3, 3, 3);
        }
        if (rgb.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);
        }

    }

    public void GetDamage(int damage)
    {
        healthPoints -= damage;
        if (healthPoints <= 0) 
        {
            healthPoints = 0;
        }
        healthbar.UpdateHealthBar();

    }

    void Dead()
    {
        Destroy(gameObject);
    }

}
