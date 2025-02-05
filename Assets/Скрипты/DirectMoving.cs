﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script moves the attached object along the Y-axis with the defined speed
/// </summary>
public class DirectMoving : MonoBehaviour {

    public Vector3 Cordinates;

    [Tooltip("Moving speed on Y axis in local space")]
    public float speed;

    //moving the object with the defined speed
    private void Update()
    {
        Cordinates = this.transform.position;
        transform.Translate(Vector3.up * speed * Time.deltaTime); 
    }
}
