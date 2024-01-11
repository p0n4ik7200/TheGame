using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMonster : Entity
{
    private float speed = 0.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;

    private void Awake()
    {

        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        dir = transform.right;
        lives = 2;
    }

    private void Update()
    {
        Move();
    }
    private void Move()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.7f, 0.1f);
        if (colliders.Length > 1) dir *= -1;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed);
        sprite.flipX = dir.x > 0.0f;



    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject == Hero.Instance.gameObject)
        //{
        //    Hero.Instance.GetDamage();
        //    lives--;
        //    Debug.Log("Monster has " + lives + " hp");
        //}

        if (lives < 1)
        {
            Die();
            Debug.Log("Monster defeated");
        }
    }
}