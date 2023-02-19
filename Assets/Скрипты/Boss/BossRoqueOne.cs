using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRoqueOne : MonoBehaviour //скрипт определяет босса, его атаки здоровье и урон
{
    public int health;
    public float velocityEnemy;
    public int scoreValue;
    public GameObject explosion;
    public Animator anim;
    public GameObject Shot; //префаб обычного выстрела
    public GameObject[] ShotSpawns; //точки для появления обычного выстрела
    public GameObject Laser;//префаб лазерного выстрела
    public GameObject[] Lasers;//точки для появления лазерного выстрела
    public GameObject SecondWeapon;//префаб дополнительного вооружения
    public int NumOfSecondaryWeapon;//количество выстрелов дополнительного вооружения
    public GameObject[] SecondWeapons;//точки для появления дополнительного вооружения
    public float fireRate = 0.5f; //Темп стрельбы
    public bool isDefeated;
    public int Damage;


    private int stage=1;//Стадия босса(определяет каким оружием стрельнет босс)
    private float nextFire = 0.0f;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = -1 * transform.up * velocityEnemy;
        anim = GetComponent<Animator>();
        isDefeated = false;
    }
    private void Update()
    {
        if(Time.time>nextFire)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player"); //Находим игрока(переделать!)
            if (player != null) //Если игрок существует
            {
                if (FindObjectOfType<PlayerMoving>().isAlive) //если игрок жив тогда можем стрелять
                {
                    if (NumOfSecondaryWeapon > 0)//Если кол-во дополнительного больше 0 тогда рандомим выстрел из всех пушек
                    {
                        switch (stage)
                        {
                            case 1://Выстрел главного калибка
                                {
                                    nextFire = Time.time + fireRate;
                                    foreach (var item in ShotSpawns)
                                    {
                                        GameObject expl = GameObject.FindGameObjectWithTag("EnemyShot");
                                        expl.GetComponent<AudioSource>().Play();
                                        Instantiate(Shot, item.transform.position, item.transform.rotation);
                                    }
                                    stage = Random.Range(1, 4);
                                    break;
                                }
                            case 2://Выстрел лазеров
                                {
                                    foreach (var item in Lasers)
                                    {
                                        GameObject expl = GameObject.FindGameObjectWithTag("LaserShot");
                                        expl.GetComponent<AudioSource>().Play();
                                        Instantiate(Laser, item.transform.position, Laser.transform.rotation);
                                    }
                                    nextFire = Time.time + fireRate;
                                    stage = Random.Range(1, 4);
                                    break;
                                }

                            case 3://Выстрел дополнительным вооружением
                                {

                                    foreach (var item in SecondWeapons)
                                    {
                                        GameObject expl = GameObject.FindGameObjectWithTag("EnemyShot");
                                        expl.GetComponent<AudioSource>().Play();
                                        Instantiate(SecondWeapon, item.transform.position, SecondWeapon.transform.rotation);
                                    }
                                    NumOfSecondaryWeapon -= 2;
                                    nextFire = Time.time + fireRate;
                                    stage = Random.Range(1, 4);

                                    break;
                                }

                            case 4://Дописать!!!
                                {
                                    nextFire = Time.time + fireRate;
                                    stage = Random.Range(1, 4);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                    else//Если дополнительного вооружения не осталось тогда стрелям всем кроме него
                    {
                        switch (stage)
                        {
                            case 1://ВЫстрел главного калибра
                                {
                                    nextFire = Time.time + fireRate;
                                    foreach (var item in ShotSpawns)
                                    {
                                        Instantiate(Shot, item.transform.position, item.transform.rotation);
                                        GameObject expl = GameObject.FindGameObjectWithTag("EnemyShot");
                                        expl.GetComponent<AudioSource>().Play();
                                    }
                                    stage = Random.Range(1, 4);
                                    break;
                                }
                            case 2://Выстрел лазеров
                                {
                                    foreach (var item in Lasers)
                                    {
                                        Instantiate(Laser, item.transform.position, Laser.transform.rotation);
                                        GameObject expl = GameObject.FindGameObjectWithTag("LaserShot");
                                        expl.GetComponent<AudioSource>().Play();
                                    }
                                    nextFire = Time.time + fireRate;
                                    stage = Random.Range(1, 4);
                                    break;
                                }

                            case 3://Вместо выстрела доп вооружения стреляем из главного
                                {

                                    nextFire = Time.time + fireRate;
                                    foreach (var item in ShotSpawns)
                                    {
                                        GameObject expl = GameObject.FindGameObjectWithTag("EnemyShot");
                                        expl.GetComponent<AudioSource>().Play();
                                        Instantiate(Shot, item.transform.position, item.transform.rotation);
                                    }
                                    stage = Random.Range(1, 4);
                                    break;
                                }

                            case 4://Опять же, дописать!!
                                {
                                    nextFire = Time.time + fireRate;
                                    stage = Random.Range(1, 4);
                                    break;
                                }
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "PlayerBullet")  //Если в босса попадает снаряд игрока снимаем здоровье, если здоровье меньше 0, 
        {                                    //тогда убиваем босса
            Destroy(collision.gameObject);

            if(health>=0)
            {
                health--;
            }
            if(health<=0)
            {
                explosion.transform.localScale = new Vector3(2, 2, 1);
                Instantiate(explosion, transform.position, transform.rotation);
                Instantiate(explosion, transform.position, transform.rotation);
                Instantiate(explosion, transform.position, transform.rotation);
                isDefeated = true;
                CountText text=FindObjectOfType<CountText>();
                text.count += 1000;
                Destroy(gameObject);
            }
        }
        if (collision.tag == "Player")//Если игрок врезается в босса, то уничтожаем игрока и снимаем боссу 10 здоровья
        {
            health -= 10;
            if(this.Damage>=0)
            Player.instance.GetDamage(this.Damage);
            else
                Player.instance.GetDamage(1);
        }
    }
}
