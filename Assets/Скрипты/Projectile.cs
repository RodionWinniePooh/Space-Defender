using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//определяет дамаг при столкновения с Projectile

public class Projectile : MonoBehaviour {

    [Tooltip("Дамаг который наносится при столкновении")]
    public float damage;

    [Tooltip("Является ли обьект пулей игрока")]
    public bool enemyBullet;

    [Tooltip("Уничтожен ли обьект коализией")]
    public bool destroyedByCollision;

    public float lifeTime;
    private float life = 0;

    private void Update()
    {
        life += Time.deltaTime;
        if (life > lifeTime)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) //Когда обьект входит в другой обьект
    {
        if (enemyBullet && collision.tag == "Player") //если этот обьект вражеская пуля и сталкивается с игроком
        {                                             //Дамажим игрока ,спавним взрыв и воспроизводим звук попадания
            Player.instance.GetDamage(damage);
            GameObject expl = GameObject.FindGameObjectWithTag("PlayerExplosion");
            expl.GetComponent<AudioSource>().Play();
            if (destroyedByCollision)
                Destruction();
        }
        else if (!enemyBullet && collision.tag == "Enemy") //если этот обьект не вражеская пуля и сталкивается с врагом
        {                                             //Дамажим врага ,спавним взрыв и воспроизводим звук попадания          
            GameObject expl = GameObject.FindGameObjectWithTag("EnemyExplosion");
            expl.GetComponent<AudioSource>().Play();
            collision.GetComponent<Enemy>().GetDamage(damage);
            if (destroyedByCollision)
                Destruction();
        }
    }

    void Destruction() 
    {
        Destroy(gameObject); //Уничтожение обьекта
    }
}


