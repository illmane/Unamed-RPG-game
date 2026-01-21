using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int CurrentScene = SceneManager.GetActiveScene().buildIndex;
            SceneController.Instance.ChangeScene(CurrentScene);
        }
    }

}
