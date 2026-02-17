using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu_manager : MonoBehaviour
{
    public GameObject Menu_background_container;
    private CanvasGroup canvasGroup;
    private ControllerActionMap Controls;
    public static event Action OnOpeningMenuFirstTime;

    void Awake()
    {
        Controls = new ControllerActionMap();
        Controls.Inventory.ToggleMenu.performed += ctx => ToggleMenu();
    }

    void Start()
    {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleMenu();
        }
    }
    private void ToggleMenu()
    {
        if (canvasGroup.alpha == 1f)
        {
            canvasGroup.alpha = 0f;
            Time.timeScale = 1;
        }
        else if (canvasGroup.alpha == 0f)
        {
            Time.timeScale = 0;
            canvasGroup.alpha = 1f;
            OnOpeningMenuFirstTime?.Invoke();
        }
    }

    void OnEnable()
    {
        Controls.Inventory.Enable();
    }

    void OnDisable()
    {
        Controls.Inventory.Disable();   
    }
}
