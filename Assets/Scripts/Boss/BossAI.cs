using Unity.VisualScripting;
using UnityEngine;

public enum BossStates
{
    Idle,
    Attack,
    Chasing
}
public class BossAI : MonoBehaviour
{
    [Header("Boss stats")]
    public float BossMovementSpeed;
    public BossStates Bossstate;
    public float attackDistance;
    public LayerMask PlayerLayer;
    public float AttackCooldown;
    public float playerDetectionRange;
    public Transform detectionPoint;
    

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform _Player;
    private float facingDirection = 2.17f;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        Bossstate = BossStates.Idle;
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (attackCooldownTimer > 0f)
        {
            attackCooldownTimer -= Time.deltaTime;
        }
        checkForPlayer();
    }       

    private void chasePlayer()
    {

        if (_Player.position.x > transform.position.x && facingDirection == 2.17f || _Player.position.x < transform.position.x && transform.localScale.x == -2.17f)
        {
            EnemyFlip();
        }

        Vector2 movementDirection = (_Player.position - transform.position).normalized;
        rb.linearVelocity = movementDirection * BossMovementSpeed;

        changeState(BossStates.Chasing);
    }

    private void EnemyFlip()
    {

        facingDirection *= -1f;
        transform.localScale = new Vector3(facingDirection, transform.localScale.y, transform.localScale.z);
    }

    private void checkForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, PlayerLayer);

        if (hits.Length > 0)
        {
            // If boss within attack range
            if (Vector2.Distance(transform.position, _Player.position) <= attackDistance && attackCooldownTimer <= 0f)
            {
                attackCooldownTimer = AttackCooldown;
                rb.linearVelocity = Vector2.zero;

                
                changeState(BossStates.Attack);
            }
            // If boss NOT within attack range
            else if (Vector2.Distance(transform.position, _Player.position) > attackDistance)
            {
                chasePlayer();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            changeState(BossStates.Idle);
        }
    }

    public void changeState(BossStates newState)
    {
        // exit out of current state
        if (Bossstate == BossStates.Idle)
        {
            anim.SetBool("IsIdle", false);
        }
        else if (Bossstate == BossStates.Attack)
        {
            anim.SetBool("isAttacking", false);
        }
        Bossstate = newState;
        
        // enter new animation state
        if (Bossstate == BossStates.Idle)
        {
            anim.SetBool("IsIdle", true);
        }
        else if (Bossstate == BossStates.Attack)
        {
            anim.SetBool("isAttacking", true);
            ChooseCertainAttack();
        }

    }

    private void ChooseCertainAttack()
    {
        int rand;
        rand = Random.Range(0, 2);

        anim.SetFloat("AttackNo", rand);
    }
}
