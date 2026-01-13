using System;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GainExperience(50);
        }
    }
    public void GainExperience(int enemyXPAmount)
    {
        StatsManager.Instance.currentXPAmount += enemyXPAmount;

        if (StatsManager.Instance.currentXPAmount >= StatsManager.Instance.TargetXPAmount)
        {
            LevelUpEvent();
        }
    }

    private void LevelUpEvent()
    {
        StatsManager.Instance.currentXPAmount -= StatsManager.Instance.TargetXPAmount;

        StatsManager.Instance.currentLevel++;
        StatsManager.Instance.StatsPoints++;

        StatsManager.Instance.TargetXPAmount = (float) Math.Floor(((StatsManager.Instance.currentLevel*0.02f+0.001f)*Math.Pow(StatsManager.Instance.currentLevel+81f, 2f))+1f);
    }
}
