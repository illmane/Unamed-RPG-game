using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private Animator anim;
    private float timer;
    private float ATTACKPOINT_POSITION = 0.7f; 

    public Transform attackPoint;
    public LayerMask enemyLayer;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Player_Movement.OnAttack += player_attack;
    }
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
    public void player_attack(float moveXValue)
    {
        if (timer <= 0f)
        {
            if (moveXValue == 1 || moveXValue == 0)
            {
                anim.SetFloat("AttackX", 1);
                attackPoint.localPosition = new Vector3(ATTACKPOINT_POSITION, attackPoint.localPosition.y, attackPoint.localPosition.z);
            }
            else if (moveXValue == -1)
            {
                anim.SetFloat("AttackX", 0);
                attackPoint.localPosition = new Vector3(-ATTACKPOINT_POSITION, attackPoint.localPosition.y, attackPoint.localPosition.z);
            }

            anim.SetBool("isAttacking", true);
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, StatsManager.Instance.attackRange, enemyLayer);
            foreach(Collider2D enemy in enemies)
            {
                if(enemy.isTrigger) continue;
            }

            if (enemies.Length > 0)
            {
                enemies[0].GetComponent<Enemy_Health>().takeDamage();
            }
            timer = StatsManager.Instance.AttackCooldown;
        }
    }

    public void player_attackFinished()
    {
        anim.SetBool("isAttacking", false);
    }
}
