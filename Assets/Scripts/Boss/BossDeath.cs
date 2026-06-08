using UnityEngine;

public class BossDeath : MonoBehaviour
{

    void Awake()
    {
        Enemy_Health.OnKillingBoss += BossKilled;
    }

    private void BossKilled()
    {
        print("Boss has been killed");
    }
}
