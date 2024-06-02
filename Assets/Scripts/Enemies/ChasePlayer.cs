using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] private bool facingRight = false;
    private GameObject player;
    [SerializeField] private float speed = 3;
    private Vector2 pos;
    [SerializeField] private float force_repulsion = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (GamePause.IsPaused || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GetHealth() <= 0)
            return;

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
