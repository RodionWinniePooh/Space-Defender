using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script defines the borders of ‘Player’s’ movement. Depending on the chosen handling type, it moves the ‘Player’ together with the pointer.
/// </summary>

[System.Serializable]
public class Borders
{
    [Tooltip("Границы экрана")]
    public float minXOffset = 1.5f, maxXOffset = 1.5f, minYOffset = 1.5f, maxYOffset = 1.5f;
    [HideInInspector] public float minX, maxX, minY, maxY;
}

public class PlayerMoving : MonoBehaviour
{

    [Tooltip("Границы экрана")]
    public Borders borders;
    Camera mainCamera;
    bool controlIsActive = true;
    public float moveSpeed;
    public bool isAlive = true;
    Rigidbody2D rb;
    private Vector3 touchPosition;
    private Vector3 direction;
    public ParticleSystem[] engines;

    public static PlayerMoving instance; //unique instance of the script for easy access to the script

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
        ResizeBorders();                //setting 'Player's' moving borders deending on Viewport's size
    }

    private void Update()
    {
        if (controlIsActive)
        {
#if UNITY_STANDALONE || UNITY_EDITOR    //Если платформа ПК

            float moveLR = Input.GetAxis("Horizontal");
            float moveFB = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveLR, moveFB);
            rb.velocity = movement * moveSpeed;

            //Двигатели
            if (Input.GetAxis("Vertical") > 0.2)
            {
                foreach (var item in engines)
                {
                    item.startLifetime = 0.4f;
                    item.maxParticles = 10;
                }
            }
            else
            {
                foreach (var item in engines)
                {
                    item.startLifetime = 0.2f;
                    item.maxParticles = 5;
                }
            }
#endif

#if UNITY_IOS || UNITY_ANDROID //если платформа iOS или Android
            if (Input.touchCount == 1) // если есть касание
            {
                Touch touch = Input.touches[0];
                Vector3 touchPosition = mainCamera.ScreenToWorldPoint(touch.position);  //расчёт точки касания в пределах игры
                touchPosition.z = transform.position.z;
                transform.position = Vector3.MoveTowards(transform.position, touchPosition, 30 * Time.deltaTime);
            }
#endif
            transform.position = new Vector3    //Если игрок вышел за границы возвращать его обратно
            (
            Mathf.Clamp(transform.position.x, borders.minX, borders.maxX),
            Mathf.Clamp(transform.position.y, borders.minY, borders.maxY),
            0
            );
        }

    }

    //Расчет границ
    void ResizeBorders()
    {
        borders.minX = mainCamera.ViewportToWorldPoint(Vector2.zero).x + borders.minXOffset;
        borders.minY = mainCamera.ViewportToWorldPoint(Vector2.zero).y + borders.minYOffset;
        borders.maxX = mainCamera.ViewportToWorldPoint(Vector2.right).x - borders.maxXOffset;
        borders.maxY = mainCamera.ViewportToWorldPoint(Vector2.up).y - borders.maxYOffset;
    }
}
