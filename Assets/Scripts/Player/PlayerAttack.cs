using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private int sight;

    public int choosedWeapon;

    public bool facingRight = true;
    private Vector2 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sight = 0;
        choosedWeapon = 1;
    }

    void Update()
    {
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

        pos = Camera.main.WorldToScreenPoint(transform.localPosition);
        LookAtCursor();
    }

    void LookAtCursor()
    {
        if (Input.mousePosition.x < pos.x && facingRight) Flip();
        else if (Input.mousePosition.x > pos.x && !facingRight) Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        var vec = transform.localScale;
        transform.localScale = new Vector2(-vec.x, vec.y);
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
