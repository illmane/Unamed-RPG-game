using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static StatsManager Instance;

    [Header("Movement Stats")]
    public float MovementSpeed;
    public float ControllerDeadZone = 0.1f;

    [Header("Player Health")]
    public float maxHealth = 10f;
    public float currentHealh = 0f;

    [Header("Player Combat")]
    public float StunnedPower;
    public float StunnedTimer;
    public float AttackCooldown;
    public float damageAmount;
    public float attackRange;

    [Header("Player Level Info")]
    public float currentXPAmount;
    public float TargetXPAmount = 300f;
    public int StatsPoints;
    public int currentLevel = 1;


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
    }
}
