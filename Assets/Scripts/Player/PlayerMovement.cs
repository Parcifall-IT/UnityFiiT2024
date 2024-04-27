using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 80f;
    private Vector2 moveVector;
    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    
    void Update()
    {
        if (GamePause.IsPaused)
            return;

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.deltaTime);
        if (moveVector.x != 0 || moveVector.y != 0)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
    }

}
