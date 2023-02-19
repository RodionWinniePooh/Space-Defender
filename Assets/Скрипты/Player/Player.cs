using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script defines which sprite the 'Player" uses and its health.
/// </summary>

public class Player : MonoBehaviour
{
    public GameObject destructionFX;
    public float health;

    public static Player instance;

    public AudioSource TakeDamage;

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    //method for damage proceccing by 'Player'
    public void GetDamage(float damage)   
    {
        FindObjectOfType<HealthCounter>().HealthChanged(damage);
        health -= damage;
        TakeDamage.Play();
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        if (health <= 0)
        {
            TakeDamage.Play();
            FindObjectOfType<PlayerMoving>().isAlive = false;
            Destruction();
        }
    }    

    //'Player's' destruction procedure
    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); //generating destruction visual effect and destroying the 'Player' object
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Boss")
        {
            FindObjectOfType<BossActivate>().Activate();
        }
        if(collision.tag=="Warning")
        {
            FindObjectOfType<WarningActivate>().Activate();
        }
    }
}
















