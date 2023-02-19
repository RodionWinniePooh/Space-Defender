using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{

    [Header("Скорость ходьбы")]
    public float speed;
    [Header("Дистанция на которой враг остановится перед игроком")]
    public float stoppingDistance;
    [Header("Дистанция на которой враг начнет убегать от игрока")]
    public float retreateDistance;  
    private Animator enemyAnim;
    [Header("Аниматор выстрела (с оружия)")]
    public Animator gunAnim;
    [Header("Здоровье врага")]
    public float Health;

    [Header("Дистанция с которой враг начнет стрельбу")]
    private float timeBtwShots;
    private float startTimeBtwShots=2f;
    public float shotDistance;

    [Header("Точка создания выстрела и префаб пули")]
    public Transform ShotPoint;
    public GameObject Bullet;

    [Header("Эффект смерти и выстрела")]
    public GameObject dieEffect;
    public GameObject ShotEffect;

    private Transform player;

    public AudioSource Shot;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnim = GetComponent<Animator>();
        timeBtwShots = startTimeBtwShots;
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            enemyAnim.SetBool("Run", true);
        }
        else
        {
            if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreateDistance)
            {
                transform.position = this.transform.position;
                enemyAnim.SetBool("Run", false);
            }
            else
            {
                if(Vector2.Distance(transform.position,player.position)<retreateDistance)
                {
                    enemyAnim.SetBool("Run", true);
                    transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
                }
            }
        }

        if (timeBtwShots <= 0)
        {
            if (Vector2.Distance(transform.position, player.position) <= shotDistance)
            {
                Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
                Instantiate(ShotEffect, ShotPoint.position, ShotPoint.rotation);
                gunAnim.SetTrigger("Shot");
                Shot.Play();
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void GetDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Instantiate(dieEffect, transform.position, transform.rotation);
        FindObjectOfType<CountText>().count += 1000;
        Destroy(gameObject);
    }

}
