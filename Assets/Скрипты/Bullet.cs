using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public GameObject impactEffect;
    public float damage;

    private float lifeTime = 1f;
    private float currentLifeTime=0f;

    public bool isEnemy = false;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }
    private void Update()
    {
        currentLifeTime += Time.deltaTime;
        if(currentLifeTime>lifeTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isEnemy)
        {
            if(collision.collider.tag != "Player")
            {
                Destroy(gameObject);
                Instantiate(impactEffect, transform.position, transform.rotation);
            }
            if (collision.collider.tag == "Enemy")
            {
                Destroy(gameObject);
                Instantiate(impactEffect, transform.position, transform.rotation);
                collision.gameObject.GetComponent<EnemyMoving>().GetDamage(damage);
            }
        }
        if(isEnemy)
        {
            if (collision.collider.tag != "Enemy")
            {
                Destroy(gameObject);
                Instantiate(impactEffect, transform.position, transform.rotation);
            }
        }
    }

}
