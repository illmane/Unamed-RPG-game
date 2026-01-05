using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject[] PlayerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateAllstats();
    }

    private void UpdateDamage()
    {
        PlayerStats[0].GetComponent<Text>().text = "Strength: " + StatsManager.Instance.damageAmount;
    }
    private void UpdateHealth()
    {
        PlayerStats[1].GetComponent<Text>().text = "Vigour: " + StatsManager.Instance.maxHealth;
    }

    private void updateAllstats()
    {
        UpdateDamage();
        UpdateHealth();
    }

}
