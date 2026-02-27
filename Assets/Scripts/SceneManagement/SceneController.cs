using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [Header("Persistent Objects")]
    public GameObject[] persistenObjects;
    private Animator TransitionAnim;

    private Vector2 FOREST_BIOME_SPAWNPOINT = new Vector2(-5.72f, -3.37f);
    private Vector2 CAVE_BIOME_SPAWNPOINT = new Vector2(-7.76F, -0.77f);
    void Awake()
    {
        TransitionAnim = GameObject.FindWithTag("SceneTansition").GetComponent<Animator>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MakeObjectsPersistent();
        }
        else
        {
            CleanUpAndDestroy();
            return;
        }

    }

    public void ChangeScene(int currentIndex, Transform _playerPosition)
    {
        TransitionAnim.SetTrigger("End");
        // check if current scene is TUTORIALAREA
        if (currentIndex == 0)
        {
            SceneManager.LoadSceneAsync("ForestBiome");
            _playerPosition.position = FOREST_BIOME_SPAWNPOINT;
        }

        if (currentIndex == 1)
        {
            SceneManager.LoadSceneAsync("CaveBiome");
            _playerPosition.position = CAVE_BIOME_SPAWNPOINT;
        }
        TransitionAnim.SetTrigger("Start");

    }

    private void MakeObjectsPersistent()
    {
        foreach (GameObject obj in persistenObjects)
        {
            if (obj != null)
            {
                DontDestroyOnLoad(obj);
            }
        }
    }

    private void CleanUpAndDestroy()
    {
        foreach (GameObject obj in persistenObjects)
        {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
