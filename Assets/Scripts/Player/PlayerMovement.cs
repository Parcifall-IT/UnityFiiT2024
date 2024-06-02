using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private Vector2 moveVector;
    private Animator anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = transform.GetComponent<Animator>();
    }

    
    void Update()
    {
        if (GamePause.IsPaused || GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GetHealth() <= 0)
            return;

        moveVector.x = Input.GetAxis("Horizontal");
        moveVector.y = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + moveVector * speed * Time.fixedDeltaTime);
        if (moveVector.x != 0 || moveVector.y != 0)
            anim.SetBool("IsRunning", true);
        else
            anim.SetBool("IsRunning", false);
    }

}
