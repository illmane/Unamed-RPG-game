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
    public BossStates state;
    public float attackDistance;
    public LayerMask PlayerLayer;
    public float attackCooldown;
    private float attackCooldownTimer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
