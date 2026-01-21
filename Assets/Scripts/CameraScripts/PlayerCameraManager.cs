using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCameraManager : MonoBehaviour
{
    private CinemachineConfiner2D _confiner2D;
    private GameObject confinerObject;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        _confiner2D = GetComponent<CinemachineConfiner2D>();
        confinerObject = GameObject.FindWithTag("Confiner");

        _confiner2D.BoundingShape2D = confinerObject.GetComponent<PolygonCollider2D>();
    }
}
