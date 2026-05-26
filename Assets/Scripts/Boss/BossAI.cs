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
    public float attackCooldown;
    public float playerDetectionRange;
    public Transform detectionPoint;

    private float attackCooldownTimer;
    private Rigidbody2D rb;
    private Transform _Player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
        Bossstate = BossStates.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        checkForPlayer();
    }


    private void checkForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, PlayerLayer);
    }
}
