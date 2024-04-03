using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 30f;
    private Vector2 moveVector;
    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            anim.SetTrigger("New Trigger");

    }

}
