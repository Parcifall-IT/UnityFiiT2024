using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFly : MonoBehaviour
{
    private GameObject Player;
    [SerializeField] private int damageAmount = 1;
    [SerializeField] float forceRepulsion = 1000f;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Player.GetComponent<IDamageable>().Damage(damageAmount);
            GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal * this.GetComponent<Rigidbody2D>().mass * forceRepulsion);
        }
    }

}
