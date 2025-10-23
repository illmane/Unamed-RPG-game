using UnityEngine;

public class Enemy_AI : MonoBehaviour
{
    public float damageAmount = 2f; 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damageAmount);
        }
    }
}
