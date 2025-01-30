using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody2D rgb;

    [SerializeField] EnemyHealthbar healthbar;

    [SerializeField] PlayerController playerController;

    public int healthPoints;
    public int healthPointsMax;
    [SerializeField] float speed;

    [SerializeField] float detectedDistance;
    [SerializeField] float atackDistance;
    [SerializeField] int damage;
    [SerializeField] float atackCooldawn;
    [SerializeField] float cooldawnTimeNow;

    [SerializeField] GameObject itemPickup;


    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }


    void Update()
    {
        cooldawnTimeNow -= Time.deltaTime;

        SearchPlayer();

        if (healthPoints <= 0)
        {
            Dead();
        }
    }

    void SearchPlayer()
    {
        if (Vector2.Distance(gameObject.transform.position, playerController.gameObject.transform.position) <= detectedDistance)
        {
            MoveToPlayer();
        }
        if (Vector2.Distance(gameObject.transform.position, playerController.gameObject.transform.position) <= atackDistance)
        {
            AtackPlayer();
        }
    }

    void MoveToPlayer()
    {
        rgb.velocity = (playerController.gameObject.transform.position - gameObject.transform.position) * speed * Time.deltaTime;

        if (rgb.velocity.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-3, 3, 3);
        }
        if (rgb.velocity.x > 0)
        {
            gameObject.transform.localScale = new Vector3(3, 3, 3);
        }
    }

    void AtackPlayer()
    {
        if (cooldawnTimeNow <= 0f)
        {
            playerController.GetDamage(damage);
            cooldawnTimeNow = atackCooldawn;
        }
    }

    public void GetDamage(int damage)
    {
        healthPoints -= damage; 
        healthbar.UpdateHealthBar();
    }

    void Dead()
    {
        var itemPick = Instantiate(itemPickup);
        itemPick.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
