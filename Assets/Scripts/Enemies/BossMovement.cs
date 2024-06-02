using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    [SerializeField] private bool facingRight = false;
    private GameObject player;
    [SerializeField] private float speed = 2;
    private Vector3 direction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized;
    }

    void FixedUpdate()
    {
        if (GamePause.IsPaused)
            return;

        transform.Translate(direction * speed * Time.deltaTime);

        if (player.transform.position.x < transform.position.x && facingRight) Flip();
        else if (player.transform.position.x > transform.position.x && !facingRight) Flip();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Wall")
        {
            var normal = (transform.position - collider.transform.position).normalized;
            direction = Vector3.Reflect(direction, normal);
        }
    }


    void Flip()
    {
        facingRight = !facingRight;
        var vec = transform.localScale;
        transform.localScale = new Vector2(-vec.x, vec.y);
    }
}
