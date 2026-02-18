using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Menu_manager : MonoBehaviour
{
    public GameObject Menu_background_container;
    private CanvasGroup canvasGroup;
    private ControllerActionMap Controls;
    public static event Action OnOpeningMenuFirstTime;

    [SerializeField] private Text XP_Progressbar_text;
    [SerializeField] private Text currentLevel_text;
    [SerializeField] private Text StatsPoint_text;

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
        // CLOSE MENU
        if (canvasGroup.alpha == 1f)
        {
            canvasGroup.alpha = 0f;
            Time.timeScale = 1;


        }
        // OPEN MENU
        else if (canvasGroup.alpha == 0f)
        {
            Time.timeScale = 0;
            canvasGroup.alpha = 1f;
            OnOpeningMenuFirstTime?.Invoke();
            DisplayAllLevelInfo();
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

    private void DisplayAllLevelInfo()
    {
        XP_Progressbar_text.text = StatsManager.Instance.currentXPAmount.ToString() + " / " + StatsManager.Instance.TargetXPAmount.ToString();
        currentLevel_text.text = "Current Level " + StatsManager.Instance.currentLevel.ToString();
        StatsPoint_text.text ="Stats Pts: " + StatsManager.Instance.StatsPoints.ToString();
    }
}
