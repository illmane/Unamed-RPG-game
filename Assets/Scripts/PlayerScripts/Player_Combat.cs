using UnityEngine;

public class Player_Combat : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Player_Movement.OnAttack += player_attack;
    }

    public void player_attack()
    {
        anim.SetBool("isAttacking", true);
    }

    public void player_attackFinished()
    {
        anim.SetBool("isAttacking", false);
        
    }
}
