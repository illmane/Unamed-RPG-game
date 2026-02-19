using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour
{
    public GameObject[] PlayerStats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Menu_manager.OnChangeStats += ShowAllstats;
        ShowAllstats(0);
    }

    private void ShowDamage()
    {
        PlayerStats[0].GetComponent<Text>().text = "Vigour: " + StatsManager.Instance.VigourPoints;
    }
    private void ShowHealth()
    {
        PlayerStats[1].GetComponent<Text>().text = "Strength: " + StatsManager.Instance.StrengthPoints;
    }

    // NEED TO ADD DEFENCE MECHANIC
    private void ShowDefenceText()
    {
        PlayerStats[2].GetComponent<Text>().text = "Defence: " + StatsManager.Instance.DefencePoints;
    }

    private void ShowSpeedText()
    {
        PlayerStats[3].GetComponent<Text>().text = "Speed: " + StatsManager.Instance.SpeedPoints;
    }   

    private void ShowAllstats(int _dummynumber)
    {
        ShowDamage();
        ShowHealth();
        ShowDefenceText();
        ShowSpeedText();
    }

}
