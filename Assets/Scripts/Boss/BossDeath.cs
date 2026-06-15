using UnityEngine;

public class BossDeath : MonoBehaviour
{
    private GameObject ExitTiles;
    void Awake()
    {
        Enemy_Health.OnKillingBoss += BossKilled;
    }

    void Start()
    {
        ExitTiles = GameObject.FindGameObjectWithTag("ExitTile");
    }

    private void BossKilled()
    {
        print("Boss has been killed");
        ExitTiles.SetActive(false);
    }

    void OnDestroy()
    {
        Enemy_Health.OnKillingBoss -= BossKilled;
    }
}
