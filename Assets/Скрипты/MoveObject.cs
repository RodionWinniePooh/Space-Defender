using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float angle = 0; // угол 
    public float radius = 0.5f; // радиус
    public bool isCircle = false; // условие движения по кругу
    public float speed; //скорость
    void Update()
    {
        if (isCircle)
        {
            angle += Time.deltaTime; // меняется плавно значение угла

            var x = Mathf.Cos(angle * speed) * radius;
            var y = Mathf.Sin(angle * speed) * radius;
            transform.position = new Vector2(x, y);
        }
    }
}
