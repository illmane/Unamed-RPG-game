using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextHandler : MonoBehaviour
{
    private Text TutorialText;
    private InputHandler.InputMode _mode;
    private bool hasKilledEnemy = false;
    private Dictionary<string, string> allTutorialText = new Dictionary<string, string>()
    {
        {"Strike_Keyboard", "Press left-mouse button to strike"},
        {"Strike_controller", "Press SQUARE to strike"}, 
        {"Menu_keyboard", "Press E to open Menu"},
        {"Menu_controller", "Press START button to open Menu"}
    };

    void Start()
    {
        TutorialText = gameObject.GetComponentInChildren<Text>();
    }

    void OnEnable()
    {
        InputHandler.OnChangedInputs += MakeModePublic;
        Enemy_Health.OnKillingTutorialEnemy += ShowMenuText;
    }

    void OnDisable()
    {
        InputHandler.OnChangedInputs -= MakeModePublic;
        Enemy_Health.OnKillingTutorialEnemy -= ShowMenuText;
    }

    private void MakeModePublic(InputHandler.InputMode mode)
    {
        _mode = mode;
        if (hasKilledEnemy == false)
        {
            ShowStrikeText();
        }
        else if (hasKilledEnemy == true)
        {
            ShowMenuText();
        }
    }

    private void ShowStrikeText()
    {
        if (_mode == InputHandler.InputMode.Keyboard)
        {
            TutorialText.text = allTutorialText["Strike_Keyboard"];
        }
        if (_mode == InputHandler.InputMode.Controller)
        {
            TutorialText.text = allTutorialText["Strike_controller"];  
        } 
    }

    private void ShowMenuText()
    {
        hasKilledEnemy = true;

        if (_mode == InputHandler.InputMode.Keyboard)
        {
            TutorialText.text = allTutorialText["Menu_keyboard"];
        }
        else if (_mode == InputHandler.InputMode.Controller)
        {
            TutorialText.text = allTutorialText["Menu_controller"];
        }
    }
}
