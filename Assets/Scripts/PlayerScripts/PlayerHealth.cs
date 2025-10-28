using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public Slider HealthSlider;
    void Start()
    {
        StatsManager.Instance.currentHealh = StatsManager.Instance.maxHealth;
        HealthSlider.maxValue = StatsManager.Instance.maxHealth;
        HealthSlider.value = StatsManager.Instance.currentHealh;
    }

    public void takeDamage(float damageAmount)
    {
        StatsManager.Instance.currentHealh -= damageAmount;
        HealthSlider.value = StatsManager.Instance.currentHealh;


        if (StatsManager.Instance.currentHealh <= 0f)
        {
            print("YOU DIED");
            StatsManager.Instance.currentHealh = StatsManager.Instance.maxHealth;
        }
    }
}
