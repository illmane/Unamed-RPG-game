using System;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public Slider HealthSlider;
    public static event Action <float> OnPlayerdeath;
    void Start()
    {
        StatsManager.Instance.currentHealh = StatsManager.Instance.maxHealth;
        HealthSlider.maxValue = StatsManager.Instance.maxHealth;
        HealthSlider.value = StatsManager.Instance.currentHealh;
    }

    public void takeDamage(float damageAmount)
    {
        StatsManager.Instance.currentHealh += damageAmount;
        HealthSlider.value = StatsManager.Instance.currentHealh;

        if (StatsManager.Instance.currentHealh <= 0f)
        {
            OnPlayerdeath?.Invoke(StatsManager.Instance.currentHealh);
        }
    }
}
