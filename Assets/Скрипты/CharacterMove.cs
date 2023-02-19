using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class CharacterMove : MonoBehaviour
{
    private CharacterController2D characterController;
    private Animator anim;

    public float runSpeed=40f;
    public bool isMobile;

    public float Health = 100f;

    public GameObject dieEffect;

    public Image health;

    float horizontalMove = 0f;
    bool jump = false;
    bool isAlive = true;
    [HideInInspector]
    public bool isWin;

    private void Start()
    {
        characterController = GetComponent<CharacterController2D>();
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
        if (!isMobile)
        {
            horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
            if (horizontalMove != 0)
                anim.SetBool("Run", true);
            else anim.SetBool("Run", false);
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetTrigger("Jump");
                jump = true;
            }
        }
        else
        {
            horizontalMove = CrossPlatformInputManager.GetAxis("Horizontal") * runSpeed;
            if (horizontalMove != 0)
                anim.SetBool("Run", true);
            else anim.SetBool("Run", false);
            if (CrossPlatformInputManager.GetButtonDown("Jump"))
            {
                anim.SetTrigger("Jump");
                jump = true;
            }
        }
    }
    private void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void GetDamage(float damage)
    {
        anim.SetTrigger("Damage");
        Health -= damage;
        health.fillAmount = Health / 100;
        if (Health <= 0)
        {
            isAlive = false;
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Slime")
        {
            collision.transform.GetComponentInParent<SlimeMovement>().Die();
        }
        if(collision.tag=="Lava")
        {
            Die();
        }
        if (collision.tag == "EnemyBullet")
        {
            GetDamage(collision.GetComponent<Bullet>().damage);
        }
        if(collision.tag == "Win")
        {
            enabled = false;
            isWin = true;
        }
    }

    public void Die()
    {
        Instantiate(dieEffect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        gameObject.GetComponent<Animator>().SetBool("Run", false);
        gameObject.GetComponent<Animator>().enabled=false;
        FindObjectOfType<Cinemachine.CinemachineVirtualCamera>().enabled = false;
    }
}