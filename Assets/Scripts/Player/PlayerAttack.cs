using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite moveLeft;
    public Sprite moveRight;
    public Sprite moveUp;
    public Sprite basic;
    private List<Sprite> sprites;

    private Rigidbody2D rb;
    private Vector2 attackVector;
    private int sight;

    public int choosedWeapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sight = 0;
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = basic;
        sprites = new List<Sprite> { basic, moveLeft, moveRight, moveUp };
        choosedWeapon = 1;
    }

    void Update()
    {
        attackVector.x = Input.GetAxis("HorizontalArrows");
        attackVector.y = Input.GetAxis("VerticalArrows");
        sight = attackVector.x < 0 ? 1 : 
            attackVector.x > 0 ? 2 : 
            //attackVector.y < 0 ? 3 : 
            //attackVector.y > 0 ? 0 :
            sight;
        spriteRenderer.sprite = sprites[sight];

        if (Input.GetKeyDown(KeyCode.Q))
            choosedWeapon = 0;

        if (Input.GetKeyDown(KeyCode.E))
            choosedWeapon = 1;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (choosedWeapon == 0)
                DistanceAttack(sight);
            else
                MeleeAttack(sight);
        }
    }

    void MeleeAttack(int sight)
    {
        Debug.Log(("Melee", sight));
    }

    void DistanceAttack(int sight)
    {
        Debug.Log(("Distance", sight));
    }
}
