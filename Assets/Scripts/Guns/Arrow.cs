﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    private List<string> IgnoreCollision = new List<string>() 
    {
        "Player",
        "Frame"
    };


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IgnoreCollision.Contains(collision.name))
        {
            Destroy(this.gameObject);
        }
    }
}
