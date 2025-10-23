using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    void Start()
    {
        StatsManager.Instance.currentHealh = StatsManager.Instance.maxHealth;
    }

    public void takeDamage(float damageAmount)
    {
        StatsManager.Instance.currentHealh -= damageAmount;

        if (StatsManager.Instance.currentHealh <= 0f)
        {
            print("YOU DIED");
            StatsManager.Instance.currentHealh = StatsManager.Instance.maxHealth;
        }
    }
}
