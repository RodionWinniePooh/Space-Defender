using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [Header("Скорость передвижения слизня")]
    public float Speed;

    [Header("Урок он атаки")]
    public float damage;

    [Header("Здоровье слизня")]
    public float Health;

    [Header("Эффект при смерти слизня")]
    public GameObject dieEffect;

    private Rigidbody2D rb;
    private bool isFlip = false;
    private Animator anim;

    private float flipRatio = 1f;
    private float nextFlip = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isFlip)
            rb.velocity = new Vector2(Speed, rb.velocity.y);
        else rb.velocity = new Vector2(-Speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBorder")
        {
            Debug.Log("Border");
            Flip();
        }
        if(collision.tag == "Bullet")
        {
            Health -= collision.gameObject.GetComponent<Bullet>().damage;
            if (Health <= 0) Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterMove>().GetDamage(damage);
        }
    }

    void Flip()
    {
        if (Time.time > nextFlip)
        {
            transform.Rotate(0f, 180f, 0f);
            isFlip = !isFlip;
            nextFlip = Time.time + flipRatio;
        }
    }

    public void Die()
    {
        Instantiate(dieEffect,transform.position,transform.rotation);
        FindObjectOfType<CountText>().count += 500;
        Destroy(gameObject);
    }
}
