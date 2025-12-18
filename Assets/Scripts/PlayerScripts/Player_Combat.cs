using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private Animator anim;
    private float timer;

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
            }
            else if (moveXValue == -1)
            {
                anim.SetFloat("AttackX", 0);
            }
            anim.SetBool("isAttacking", true);
            timer = StatsManager.Instance.AttackCooldown;
        }
    }

    public void player_attackFinished()
    {
        anim.SetBool("isAttacking", false);
    }
}
