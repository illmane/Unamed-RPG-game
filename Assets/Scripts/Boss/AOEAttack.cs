using System.Collections;
using UnityEngine;

public class AOEAttack : MonoBehaviour
{
    public Transform fireballCentrePoint;
    public float FireballRadius;
    public LayerMask PlayerLayer;
    public float FireballDamange;
    public float FireballDestroyTimer;

    void Start()
    {
        StartCoroutine(destoryFireball());
    }

    private void damagePlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(fireballCentrePoint.position, FireballRadius, PlayerLayer);

        if (hits.Length > 0)
        {
            hits[0].GetComponent<PlayerHealth>().takeDamage(-FireballDamange);
            hits[0].GetComponent<Player_Movement>().GetStunned(gameObject.transform);
        }
    }

    private IEnumerator destoryFireball()
    {
        yield return new WaitForSeconds(FireballDestroyTimer);
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(fireballCentrePoint.position, FireballRadius);
    }
}
