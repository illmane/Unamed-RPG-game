using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float damageAmount = 2f;
    public float enemySpeed;


    private Rigidbody2D rb;
    private Transform _Player;
    private bool isChasing;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        enemyChasing();
    }

    // damage player if touched (active hitbox)
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damageAmount);
        }
    }

    private void enemyChasing()
    {
        if (isChasing == true)
        {
            Vector2 movementDirection = (_Player.position - transform.position).normalized;
            rb.linearVelocity = movementDirection * enemySpeed;
            
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_Player == null)
            {
                _Player = collision.transform;
            }
            isChasing = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            isChasing = false;
        }
    }
}
