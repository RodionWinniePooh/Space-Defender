using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Скрипт определяет свойства и здоровья врагов
public class Enemy : MonoBehaviour {

    #region FIELDS
    [Tooltip("Health points in integer")]
    public float health;

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;

    CountText text;

    private AudioSource TakeDamage;

    [HideInInspector] public int shotChance; //Шанс выстрела в ходе движения
    [HideInInspector] public float shotTimeMin, shotTimeMax; //Время после которого может быть сделан выстрел(мин и макс)
    #endregion

    private void Start()
    {
        text = FindObjectOfType<CountText>();
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
        TakeDamage = GameObject.FindGameObjectWithTag("EnemyExplosion").GetComponent<AudioSource>();
    }

    //функция выстрела
    void ActivateShooting() 
    {
        if (Random.value < (float)shotChance / 100)       //если рандомится число меньше чем шанс стрельбы тогда происходит выстрел
        {
            GameObject expl = GameObject.FindGameObjectWithTag("EnemyShot");
            expl.GetComponent<AudioSource>().Play();
            Instantiate(Projectile,  gameObject.transform.position, Quaternion.identity);             
        }
    }

    //method of getting damage for the 'Enemy'
    public void GetDamage(float damage) 
    {
        health -= damage;
        TakeDamage.Play();//Уменьшение здоровья,если он меньше или равно 0 тогда уничтожаем врага
        if (health <= 0)
        {
            Destruction();
            text.count += 100;
        }
        else
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }    

    //Если враг сталкивается с игроком тогда игрок получает дамаг который заложен в Projectile.cs
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (Projectile.GetComponent<Projectile>() != null)
            {
                Player.instance.GetDamage(Projectile.GetComponent<Projectile>().damage);
            }
            else
                Player.instance.GetDamage(1);
        }
    }

    //Уничтожение врага
    void Destruction()                           
    {        
        Instantiate(destructionVFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}
