using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Enemy_Health : MonoBehaviour
{
   public float currentHealth;
   public float Maxhealth;

    void Start()
    {
        currentHealth = Maxhealth;
    }

    public void takeDamage()
    {
        currentHealth -= StatsManager.Instance.damageAmount;

        if (currentHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
