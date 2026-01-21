using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    [Header("Persistent Objects")]
    public GameObject[] persistenObjects;

    void Awake()
    {
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

    public void ChangeScene(int currentIndex)
    {
        // check if current scene is TUTORIALAREA
        if (currentIndex == 0)
        {
            SceneManager.LoadSceneAsync("ForestBiome");
        }
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
