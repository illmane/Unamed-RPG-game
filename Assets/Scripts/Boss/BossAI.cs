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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        Bossstate = BossStates.Idle;
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

        Bossstate = BossStates.Chasing;
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
            if (Vector2.Distance(transform.position, _Player.position) <= attackDistance && attackCooldownTimer <= 0f)
            {
                attackCooldownTimer = AttackCooldown;
                rb.linearVelocity = Vector2.zero;
                print("I want to attack!!");
                Bossstate = BossStates.Attack;
            }
            else if (Vector2.Distance(transform.position, _Player.position) > attackDistance)
            {
                chasePlayer();
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            Bossstate = BossStates.Idle;
        }
    }
}
