using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource MusicSource;

    [Header("Audio Clip")]
    public AudioClip MainMenuTheme;
    private int mainMenuIndex;

    void Start()
    {
        mainMenuIndex = SceneManager.GetActiveScene().buildIndex;

        if (mainMenuIndex == 4)
        {
            PlayMainMenu();
        }
        else
        {
            return;
        }
    }


    private void PlayMainMenu()
    {
        MusicSource.clip = MainMenuTheme;
        MusicSource.Play();
    }

    public void PlaySFX()
    {
        return;
    }
}
