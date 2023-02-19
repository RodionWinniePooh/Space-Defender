using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Weapon : MonoBehaviour
{
    public Transform ShotPoint;
    public Transform Bullet;
    public GameObject ShotEffect;

    public float fireRate = 0.5f;

    public Animator anim;

    public int weaponNum;

    private float nextFire = 0f;

    public AudioSource Shot;

    private void Start()
    {
       //if (weaponNum == 1)
       //    Shot=GameObject.FindGameObjectWithTag("Colt").GetComponent<AudioSource>();
       //if (weaponNum == 2)
       //    Shot=GameObject.FindGameObjectWithTag("M4").GetComponent<AudioSource>();
       //if (weaponNum == 3)
       //    Shot=GameObject.FindGameObjectWithTag("AK-47").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!FindObjectOfType<CharacterMove>().isMobile)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (Time.time > nextFire)
                {
                    Shoot();
                    nextFire = Time.time + fireRate;
                }
            }
        }
        else
        {
            if (CrossPlatformInputManager.GetButtonDown("Shot"))
            {
                if (Time.time > nextFire)
                {
                    Shoot();                   
                    nextFire = Time.time + fireRate;
                }
            }
        }
    }

    void Shoot()
    {
        Instantiate(ShotEffect, ShotPoint.position, ShotPoint.rotation).transform.SetParent(transform);
        anim.SetTrigger("Shot");
        Shot.Play();
        Instantiate(Bullet, ShotPoint.position, ShotPoint.rotation);
    }
}
