using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion target = Quaternion.Euler(Random.Range(0, 360), 0, 0);
        this.transform.rotation = Quaternion.Slerp(transform.rotation, target, 0);
        rb.velocity = this.transform.up*-speed*Time.deltaTime;
    }
}
