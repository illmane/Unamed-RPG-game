using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject[] PlayerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ShowAllstats();
    }

    private void ShowDamage()
    {
        PlayerStats[0].GetComponent<Text>().text = "Strength: " + StatsManager.Instance.damageAmount;
    }
    private void ShowHealth()
    {
        PlayerStats[1].GetComponent<Text>().text = "Vigour: " + StatsManager.Instance.maxHealth;
    }

    private void ShowAllstats()
    {
        ShowDamage();
        ShowHealth();
    }

}
