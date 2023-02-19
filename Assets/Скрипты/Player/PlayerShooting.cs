using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//guns objects in 'Player's' hierarchy
[System.Serializable]
public class Guns
{
    public GameObject centralGun;
    public GameObject rightGun;
    public GameObject leftGun;
    public ParticleSystem centralGunVFX;
    public ParticleSystem rightGunVFX;
    public ParticleSystem leftGunVFX;
}

public class PlayerShooting : MonoBehaviour {

    [Tooltip("shooting frequency. the higher the more frequent")]
    public float fireRate;

    [Tooltip("projectile prefab")]
    public GameObject Shot;
    public AudioSource ShotSound;

    [HideInInspector] public float nextFire;
    public bool isFinish=false;

    [Range(1,3)]
    public int playerTire;

    [Tooltip("current weapon power")]
    [Range(1, 3)]
    public int weaponPower = 1; 

    public Guns guns;
    bool shootingIsActive = true; 
    public int maxweaponPower = 2; 
    public static PlayerShooting instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        //receiving shooting visual effects components
        if (guns.centralGun != null)
            guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
        if (guns.rightGun != null)
            guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();
        if (guns.leftGun != null)
            guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (shootingIsActive)
        {
            if (Time.time > nextFire)
            {
                MakeAShot();                                                         
                nextFire = Time.time + 1 / fireRate;
            }
        }
    }

    //method for a shot
    void MakeAShot()
    {
        if (!isFinish)
        {
            switch (weaponPower) // according to weapon power 'pooling' the defined anount of projectiles, on the defined position, in the defined rotation
            {
                case 1:
                    if (playerTire == 1)
                    {
                        if (guns.centralGun != null)
                        {
                            CreateLazerShot(Shot, guns.centralGun.transform.position, Vector3.zero);
                            guns.centralGunVFX.Play();
                        }
                    }
                    if (playerTire == 2)
                    {
                        if (guns.rightGun != null)
                        {
                            CreateLazerShot(Shot, guns.rightGun.transform.position, Vector3.zero);
                            guns.rightGunVFX.Play();
                        }
                        if (guns.leftGun != null)
                        {
                            CreateLazerShot(Shot, guns.leftGun.transform.position, Vector3.zero);
                            guns.leftGunVFX.Play();
                        }
                    }
                    if (playerTire == 3)
                    {
                        if (guns.centralGun != null)
                        {
                            CreateLazerShot(Shot, guns.centralGun.transform.position, Vector3.zero);
                            guns.centralGunVFX.Play();
                        }
                        if (guns.rightGun != null)
                        {
                            CreateLazerShot(Shot, guns.rightGun.transform.position, Vector3.zero);
                            guns.rightGunVFX.Play();
                        }
                        if (guns.leftGun != null)
                        {
                            CreateLazerShot(Shot, guns.leftGun.transform.position, Vector3.zero);
                            guns.leftGunVFX.Play();
                        }
                    }
                    break;
                case 2:
                    if (playerTire == 1)
                    {
                        if (guns.centralGun != null)
                        {
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, 5));
                            guns.centralGunVFX.Play();
                        }
                    }
                    if (playerTire == 2)
                    {
                        if (guns.rightGun != null)
                        {
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, 5));
                            guns.rightGunVFX.Play();
                        }
                        if (guns.leftGun != null)
                        {
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                            guns.leftGunVFX.Play();
                        }
                    }
                    if (playerTire == 3)
                    {
                        if (guns.centralGun != null)
                        {
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, 5));
                            guns.centralGunVFX.Play();
                        }
                        if (guns.rightGun != null)
                        {
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, 5));
                            guns.rightGunVFX.Play();
                        }
                        if (guns.leftGun != null)
                        {
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                            guns.leftGunVFX.Play();
                        }
                    }
                    break;
                case 3:
                    if (playerTire == 1)
                    {
                        if (guns.centralGun != null)
                        {
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.centralGun.transform.position, Vector3.zero);
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, 5));
                            guns.centralGunVFX.Play();
                        }
                    }
                    if (playerTire == 2)
                    {
                        if (guns.rightGun != null)
                        {
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, 5));
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, 0));
                            guns.rightGunVFX.Play();
                        }
                        if (guns.leftGun != null)
                        {
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, 0));
                            guns.leftGunVFX.Play();
                        }
                    }
                    if (playerTire == 3)
                    {
                        if (guns.centralGun != null)
                        {
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.centralGun.transform.position, Vector3.zero);
                            CreateLazerShot(Shot, guns.centralGun.transform.position, new Vector3(0, 0, 5));
                            guns.centralGunVFX.Play();
                        }
                        if (guns.rightGun != null)
                        {
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.rightGun.transform.position, new Vector3(0, 0, 5));
                            guns.rightGunVFX.Play();
                        }
                        if (guns.leftGun != null)
                        {
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, -5));
                            CreateLazerShot(Shot, guns.leftGun.transform.position, new Vector3(0, 0, 5));
                            guns.leftGunVFX.Play();
                        }
                    }
                    break;
            }
        }
    }

    void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot) //translating 'pooled' lazer shot to the defined position in the defined rotation
    {
        Instantiate(lazer, pos, Quaternion.Euler(rot));
        ShotSound.Play();
    }
}
