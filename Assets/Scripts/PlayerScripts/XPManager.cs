using System;
using UnityEngine;

public class XPManager : MonoBehaviour
{
    private float X = ((StatsManager.Instance.currentLevel+81f)-92f)*0.02f;
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

        StatsManager.Instance.TargetXPAmount = (float) Math.Floor(((X+0.1f)*Math.Pow(StatsManager.Instance.currentLevel+81f, 2f))+1f);
    }
}


