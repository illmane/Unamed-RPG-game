using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class SkillPointsManager : MonoBehaviour
{
    public static SkillPointsManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Menu_manager.OnChangeStats += ChangeStats;
    }

    private void ChangeStats(int SelectedStat)
    {
        if (StatsManager.Instance.StatsPoints > 0)
        {
            if (SelectedStat == 0)
            {
                StatsManager.Instance.maxHealth += StatsManager.Instance.StatsPoints * 10;
                StatsManager.Instance.VigourPoints++;
            }
            else if (SelectedStat == 1)
            {
                StatsManager.Instance.damageAmount += StatsManager.Instance.StatsPoints * 5;
                StatsManager.Instance.StrengthPoints++;
            }
            else if (SelectedStat == 2)
            {
                StatsManager.Instance.Defence += StatsManager.Instance.StatsPoints * 5;
                StatsManager.Instance.DefencePoints++;
            }
            else if (SelectedStat == 3)
            {
                StatsManager.Instance.MovementSpeed += StatsManager.Instance.StatsPoints * 1.2f;
                StatsManager.Instance.SpeedPoints++;
            }
            
            StatsManager.Instance.StatsPoints--;
        }
        else
        {
            print("INSUFFICIENT SKILL POINTS");
        }
    }

}
