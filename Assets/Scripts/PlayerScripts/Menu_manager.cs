using System;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Menu_manager : MonoBehaviour
{
    public GameObject Menu_background_container;
    public static event Action OnOpeningMenuFirstTime;
    public Text[] AllStats;

    private ControllerActionMap Controls;
    private CanvasGroup canvasGroup;
    private int SlotNumber = 0;
    [SerializeField] private Text XP_Progressbar_text;
    [SerializeField] private Text currentLevel_text;
    [SerializeField] private Text StatsPoint_text;


    void Awake()
    {
        Controls = new ControllerActionMap();
        Controls.Inventory.ToggleMenu.performed += ctx => ToggleMenu();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ToggleMenu();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && canvasGroup.alpha == 1f)
        {
            NavigateThroughStats(1);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && canvasGroup.alpha == 1f)
        {
            NavigateThroughStats(-1);
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

    private void NavigateThroughStats(int direction)
    {
        DeselectAllSlots();
        SlotNumber += direction;

        if (SlotNumber >= 4)
        {
            SlotNumber = 0;
        }
        else if (SlotNumber <= -1)
        {
            SlotNumber = 3;
        }
        AllStats[SlotNumber].color = Color.yellow;
    }

    private void DeselectAllSlots()
    {
        for (int i = 0; i < AllStats.Length; i++)
        {
            AllStats[i].color = Color.white;
        }
    }
}
