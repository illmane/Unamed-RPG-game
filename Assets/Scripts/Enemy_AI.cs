using Unity.VisualScripting;
using UnityEngine;


public enum EnemyState
{
    Idle,
    Chasing
}
public class Enemy_AI : MonoBehaviour
{
    public float damageAmount = 2f;
    public float enemySpeed;
    public EnemyState state;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform _Player;
    private float facingDirection = 2.2f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        // ChangeState(EnemyState.Idle);
        state = EnemyState.Idle;
    }

    void FixedUpdate()
    {
        if (state == EnemyState.Chasing)
        {
            enemyChasing();
        }
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
        if (_Player.position.x > transform.position.x && facingDirection == -2.2f || _Player.position.x < transform.position.x && facingDirection == 2.2f)
        {
            EnemyFlip();
        }
        Vector2 movementDirection = (_Player.position - transform.position).normalized;
        rb.linearVelocity = movementDirection * enemySpeed;
    }
    private void EnemyFlip()
    {
        facingDirection *= -1;
        transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (_Player == null)
            {
                _Player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        }
    }

    private void ChangeState(EnemyState newState)
    {
        //exit the current state
        if (state == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        // updates the state
        state = newState;

        // enter the new state animation
        if (state == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }

    }
}
