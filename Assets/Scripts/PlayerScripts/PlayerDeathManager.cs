using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    public static PlayerDeathManager instance;

    private bool isDead = false;
    private CanvasGroup canvasGroup;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        PlayerHealth.OnPlayerdeath += GameOver;
    }
    
    private void GameOver(float currentHeath)
    {
        if (currentHeath <= 0f && isDead == false)
        {
            isDead = true;
            canvasGroup.alpha = 1;
        }
    }
}
