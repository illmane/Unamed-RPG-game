using System;
using UnityEngine;

public enum RockEnemyState
{
    Idle,
    Chasing,
    Attacking,
    RollingUp
}
public class RockEnemy_AI : MonoBehaviour
{
    public float enemySpeed;
    public RockEnemyState state;
    public float attackDistance;
    public float playerDetectionRange;
    public Transform detectionPoint;
    public LayerMask PlayerLayer;
    public float attackCooldown;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform _Player;
    private float facingDirection = 1.33f;
    private float attackCooldownTimer;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        state = RockEnemyState.Idle;


    }

    // Update is called once per frame
    void Update()
    {
        if (attackCooldownTimer > 0)
        {
            attackCooldownTimer -= Time.deltaTime;
        }

        CheckForPlayer();

        if (state == RockEnemyState.Chasing)
        {
            enemyChasing();
        }
        else if (state == RockEnemyState.Attacking)
        {
            rb.linearVelocity = Vector2.zero;
        }
    }

    private void enemyChasing()
    {
        if (_Player.position.x > transform.position.x && facingDirection == 1.33f || _Player.position.x < transform.position.x && facingDirection == -1.33f)
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
        // If player is within detection range
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, PlayerLayer);
        
        if (hits.Length > 0)
        {
            _Player = hits[0].transform;

            // If player is within detection AND attack range
            if (Vector2.Distance(transform.position, _Player.position) <= attackDistance && attackCooldownTimer <= 0){

                if (_Player.position.x > transform.position.x)
                {
                    print("player is RIGHT of me");
                }
                else if (_Player.position.x < transform.position.x)
                {
                    print("player is LEFT of me");
                }

                if (_Player.position.y < transform.position.y)
                {
                    print("player is BELOW me");
                }
                else if (_Player.position.y > transform.position.y)
                {
                    print("player is ABOVE me");
                    
                }
                attackCooldownTimer = attackCooldown;

                ChangeState(RockEnemyState.Attacking);
            }
            else if (Vector2.Distance(transform.position, _Player.position) > attackDistance && state != RockEnemyState.Attacking && state != RockEnemyState.Chasing)
            {
                ChangeState(RockEnemyState.RollingUp);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            ChangeState(RockEnemyState.Idle);
        }
    }

    private void ChangeState(RockEnemyState newState)
    {
        //exit the current state
        if (state == RockEnemyState.Chasing)
        {
            anim.SetBool("isChasing", false);
        }
        else if (state == RockEnemyState.Attacking)
        {
            anim.SetBool("isAttacking", false);
        }
        else if (state == RockEnemyState.Idle)
        {
            anim.SetBool("isIdle", false);
        }
        else if (state == RockEnemyState.RollingUp)
        {
            anim.SetBool("isRollingUp", false);
        }
        // updates the state
        state = newState;

        // enter the new state animation
        if (state == RockEnemyState.Chasing)
        {
            anim.SetBool("isChasing", true);
        }
        else if (state == RockEnemyState.Attacking)
        {
            anim.SetBool("isAttacking", true);
        }
        else if (state == RockEnemyState.Idle)
        {
            anim.SetBool("isIdle", true);
        }
        else if (state == RockEnemyState.RollingUp)
        {
            anim.SetBool("isRollingUp", true);
        }
    }
}
