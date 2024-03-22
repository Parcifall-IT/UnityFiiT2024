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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = basic;
        sprites = new List<Sprite> { moveLeft, moveRight, moveUp, basic };
    }

    void Update()
    {
        attackVector.x = Input.GetAxis("HorizontalArrows");
        attackVector.y = Input.GetAxis("VerticalArrows");
        sight = attackVector.x < 0 ? 0 : attackVector.x > 0 ? 1 : attackVector.y < 0 ? 2 : attackVector.y > 0 ? 3 : 3;
        spriteRenderer.sprite = sprites[sight];
        if(attackVector.x + attackVector.y != 0)
            Attack(sight);
    }

    void Attack(int sight)
    {
        Debug.Log(sight);
    }
}
