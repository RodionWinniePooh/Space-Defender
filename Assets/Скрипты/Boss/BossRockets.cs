using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRockets : MonoBehaviour //Скрипт определяет одну из атак босса - самонаводящиеся ракеты
{
    private PlayerMoving player; //Игрок
    public float speed; //Скорость ракет
    public GameObject explosion; //Префаб взрыва ракет
    public float lifeTime;// время жизни

    private float life=0;
    

    public void Start()
    {
        player = FindObjectOfType<PlayerMoving>(); //находим игока на сцене
    }

    public void Update()
    {
        if (player.isAlive) //Если игрок живой и время жизни данной ракеты меньше заданного тогда она летит на игрока
        {
            life += Time.deltaTime;
            if (life < lifeTime)
            {
                Vector3 delta = transform.position - player.transform.position;
                delta.Normalize();
                float moveSpeed = speed * Time.deltaTime;
                transform.position = transform.position + (delta * moveSpeed);
            }
            else //Если время жизни ракеты больше изаданного тогда уничтожаем
            {
                DestroyRocket();
            }
        }
        else //Если игрок погиб тогда уничтожаем
        {
            DestroyRocket();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player") //Если заходим в коализию игрока тогда наносим ему дамаг и взрываем ракету
        {
            DestroyRocket();
        }
    }

    private void DestroyRocket()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        GameObject expl = GameObject.FindGameObjectWithTag("RocketExplosion");
        expl.GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }
}
