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
    public float playerDetectionRange = 2.3f;
    public Transform detectionPoint;
    public LayerMask PlayerLayer;
    public float attackCooldown;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform _Player;
    private float facingDirection = 2.2f;
    private float attackCooldownTimer;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        state = EnemyState.Idle;
    }

    void Update()
    {
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
        // constantly check if player is within range
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
        if (_Player.position.x > transform.position.x && facingDirection == 2.2f || _Player.position.x < transform.position.x && facingDirection == -2.2f)
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
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, PlayerLayer);
        // If player is within detection range
        if (hits.Length > 0)
        {
            _Player = hits[0].transform;
            // If player is within detection AND attack range

            if (Vector2.Distance(transform.position, _Player.position) <= attackDistance && attackCooldownTimer <= 0){

                attackCooldownTimer = attackCooldown;
                ChangeState(EnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, _Player.position) > attackDistance)
            {
                ChangeState(EnemyState.Chasing);
            }
        }
        else
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
        else if (state == EnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
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
        else if (state == EnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
    }
}
