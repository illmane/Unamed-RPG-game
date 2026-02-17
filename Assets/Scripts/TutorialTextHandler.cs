using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class TutorialTextHandler : MonoBehaviour
{
    private Text TutorialText;
    private InputHandler.InputMode _mode;
    private bool hasKilledEnemy = false;
    private bool PassedArchway = false;

    private Dictionary<string, string> allTutorialText = new Dictionary<string, string>()
    {
        {"Strike_Keyboard", "Press left-mouse button to strike"},
        {"Strike_controller", "Press SQUARE to strike"}, 
        {"Menu_keyboard", "Press Q to open Menu"},
        {"Menu_controller", "Press START button to open Menu"},
        {"Dash_Keyboard", "Press E to Dash"},
        {"Dash_controller", "Press RT to Dash"}
    };

    void Start()
    {
        TutorialText = gameObject.GetComponentInChildren<Text>();
        TriggerDashText.OnPassingArchway += ShowDashText;
        Menu_manager.OnOpeningMenuFirstTime += HideMentText;
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
        else if (hasKilledEnemy == true && PassedArchway == false)
        {
            ShowMenuText();
        }
        else if (PassedArchway == true)
        {
            ShowDashText();
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

    private void ShowDashText()
    {
        PassedArchway = true;
        if (_mode == InputHandler.InputMode.Keyboard)
        {
            TutorialText.text = allTutorialText["Dash_Keyboard"];
        }
        if (_mode == InputHandler.InputMode.Controller)
        {
            TutorialText.text = allTutorialText["Dash_controller"];  
        } 

        StartCoroutine(hideDashText());
    }

    private IEnumerator hideDashText()
    {
        yield return new WaitForSeconds(3);
        if (PassedArchway == true)
        {
            TutorialText.text = "";
        }
    }

    private void HideMentText()
    {
        if (hasKilledEnemy == true && PassedArchway == false)
        {
            TutorialText.text = "";
        }
    }
}
