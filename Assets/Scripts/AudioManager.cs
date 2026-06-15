using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] AudioSource MusicSource;

    [Header("Audio Clip")]
    public AudioClip MainMenuTheme;
    public AudioClip BossTheme;
    private int SceneIndex;

    void Start()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;

        // MAIN MENU SCREEN
        if (SceneIndex == 0)
        {
            PlayMainMenu();
        }
        // BOSS ROOM
        else if (SceneIndex == 4)
        {
            PlayBossTheme();
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

    private void PlayBossTheme()
    {
        MusicSource.clip = BossTheme;
        MusicSource.Play();
    }

    
}
