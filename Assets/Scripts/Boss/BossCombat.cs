using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public float DamangeAmount;
    public float attackRadius;
    public LayerMask PlayerLayer;

    public Transform AttackPoint;

    public void DamagePlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius, PlayerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().takeDamage(DamangeAmount);
            hits[0].GetComponent<Player_Movement>().GetStunned(gameObject.transform);
        }
    }
}
