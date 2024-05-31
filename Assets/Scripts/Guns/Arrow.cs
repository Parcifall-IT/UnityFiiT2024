using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb;
    private List<string> IgnoreCollision = new List<string>() 
    {
        "Player",
        "Frame",
        "SpawnWaveButton",
        "AnotherRoom",
        "Room",
        "table"
    };

    [SerializeField] private float damageAmount = 5f;
    [SerializeField] private int through;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var diference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        var rotateZ = Mathf.Atan2(diference.y, diference.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ);

        rb.velocity = transform.up * speed;

        through = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IgnoreCollision.Contains(collision.name))
        {
            if (through <= 1)
            {
                Destroy(gameObject);
            }

            through -= 1;

            if (collision.gameObject.TryGetComponent<IDamageable>(out var damageable))
                damageable.Damage(damageAmount);
        }
    }

    public void SetDamage(int ammount)
    {
        damageAmount = ammount;
    }
}
