using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public float damageAmount;
    public LayerMask PlayerLayer;
    public float HitboxRadius;

    private Transform attackPoint;
    void Start()
    {
        attackPoint = gameObject.GetComponentInChildren<Transform>();
        
    }

    // void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Player")
    //     {
    //         collision.gameObject.GetComponent<PlayerHealth>().takeDamage(-damageAmount);
    //     }
    // }
    
    public void Attack()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, HitboxRadius, PlayerLayer);
        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().takeDamage(-damageAmount);
            hits[0].GetComponent<Player_Movement>().GetStunned(gameObject.transform);
        }    
    }

}
