﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private bool facingRight = false;
    [SerializeField] private GameObject player;
    [SerializeField] private float speed;
    private Vector2 pos;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        pos = transform.position;
        if (player.transform.position.x < pos.x && facingRight) Flip();
        else if (player.transform.position.x > pos.x && !facingRight) Flip(); 
    }
    void Flip()
    {
        facingRight = !facingRight;
        var vec = transform.localScale;
        transform.localScale = new Vector2(-vec.x, vec.y);
    }
}
