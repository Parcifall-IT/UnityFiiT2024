using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Gun;

    private double attackAngle;

    public int choosedWeapon;

    public bool facingRight = true;
    private Vector2 pos;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        attackAngle = 0;
        choosedWeapon = 1;
    }

    void Update()
    {
        pos = Camera.main.WorldToScreenPoint(transform.localPosition);

        attackAngle = FindAngle(pos, Input.mousePosition);
        if (facingRight)
            attackAngle = 360 - attackAngle;


        if (Input.GetKeyDown(KeyCode.Q))
            choosedWeapon = 0;

        if (Input.GetKeyDown(KeyCode.E))
            choosedWeapon = 1;

        if (Input.GetMouseButtonDown(0))
        {
            if (choosedWeapon == 0)
                DistanceAttack(attackAngle);
            else
                MeleeAttack(attackAngle);
        }

        RotateGun(attackAngle);
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

    private double FindAngle(Vector2 a, Vector2 b)
    {
        var angle = Mathf.Acos((b.y - a.y) / Mathf.Sqrt((b - a).x * (b - a).x + (b - a).y * (b - a).y)) * 180 / Mathf.PI;
        return angle;
    }

    void MeleeAttack(double angle)
    {
        Debug.Log(("Melee"));
    }

    void DistanceAttack(double angle)
    {
        Debug.Log(("Distance"));
    }

    void RotateGun(double angle)
    {
        Gun.transform.rotation = Quaternion.Euler(0, 0, (float)attackAngle);
    }
}
