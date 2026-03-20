using UnityEngine;
using UnityEngine.SceneManagement;

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
        PlayerHealth.OnPlayerdeath += GameOver;
    }

    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
        
    }

    void Update()
    {
        CheckRestartCurrentScene();
    }

    private void GameOver(float currentHeath)
    {
        if (currentHeath <= 0f && isDead == false)
        {
            isDead = true;
            canvasGroup.alpha = 1;
        }
    }

    private void CheckRestartCurrentScene()
    {
        if (Input.GetKeyDown(KeyCode.Return) && isDead == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            canvasGroup.alpha = 0;
            isDead = false;
        }
    }

    private void OnDestroy()
    {
        PlayerHealth.OnPlayerdeath -= GameOver;
    }
}
