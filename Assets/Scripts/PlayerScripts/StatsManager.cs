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
