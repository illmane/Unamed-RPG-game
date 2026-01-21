using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{
    private Transform PlayerPosition;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            int CurrentScene = SceneManager.GetActiveScene().buildIndex;
            PlayerPosition = collision.transform;
            SceneController.Instance.ChangeScene(CurrentScene, PlayerPosition);
        }
    }

}
