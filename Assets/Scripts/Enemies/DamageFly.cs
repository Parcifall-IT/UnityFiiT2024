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
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Audio>().PlayAm();
            Player.GetComponent<IDamageable>().Damage(damageAmount);
            GetComponent<Rigidbody2D>().AddForce(collision.contacts[0].normal * this.GetComponent<Rigidbody2D>().mass * forceRepulsion);
        }
    }

}
