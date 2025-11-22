using Unity.VisualScripting;
using UnityEngine;


public enum EnemyState
{
    Idle,
    Chasing,
    Attacking
}
public class Enemy_AI : MonoBehaviour
{
    public float enemySpeed;
    public EnemyState state;
    public float attackDistance;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform _Player;
    private float facingDirection = 2.2f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        state = EnemyState.Idle;
    }

    void Update()
    {
        CheckForPlayer();
        if (state == EnemyState.Chasing)
        {
            enemyChasing();
        }
        else if (state == EnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    // damage player if touched (active hitbox)
    private void enemyChasing()
    {
        if (Vector2.Distance(transform.position, _Player.transform.position) <= attackDistance)
        {
            ChangeState(EnemyState.Attacking);
        }
        else if (_Player.position.x > transform.position.x && facingDirection == 2.2f || _Player.position.x < transform.position.x && facingDirection == -2.2f)
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
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll();
        
        if (collision.gameObject.tag == "Player")
        {
            if (_Player == null)
            {
                _Player = collision.transform;
            }
            ChangeState(EnemyState.Chasing);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
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
        else if (state == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
        }
        // updates the state
        state = newState;

        // enter the new state animation
        if (state == EnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
        else if (state == EnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }
    }
}
