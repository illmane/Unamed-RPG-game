using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            print("is this even activating");
            int CurrentScene = SceneManager.GetActiveScene().buildIndex;
            
            SceneController.Instance.ChangeScene(CurrentScene, collision.transform);
        }
    }
}
