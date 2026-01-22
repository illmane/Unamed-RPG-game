using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance;

    public InputMode currentInputMode;
    public InputMode LastFrameInputMode;
    public static event Action <InputMode> OnChangedInputs;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentInputMode = InputMode.Keyboard;
        LastFrameInputMode = InputMode.Keyboard;
    }

    void Update()
    {
        UpdateInputMode();
        DetectChangeInInput();
    }

    private void UpdateInputMode()
    {
        if (Input.GetJoystickNames().Length == 0)
        {
            //if no controllers are plugged in then set variable to keyboard
            currentInputMode = InputMode.Keyboard;
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                currentInputMode = InputMode.Controller;
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button0)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button2)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button3)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button4)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button5)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button6)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button7)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button8)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button9)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button10)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button11)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button12)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button13)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button14)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button15)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button16)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button17)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button18)) currentInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button19)) currentInputMode = InputMode.Controller;
            else currentInputMode = InputMode.Keyboard;
        }
    }

    private void DetectChangeInInput()
    {
        if (currentInputMode != LastFrameInputMode)
        {
            OnChangedInputs?.Invoke(currentInputMode);
        }

        if (Input.GetJoystickNames().Length == 0)
        {
            //if no controllers are plugged in then set variable to keyboard
            LastFrameInputMode = InputMode.Keyboard;
        }

        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                LastFrameInputMode = InputMode.Controller;
            }

            else if (Input.GetKeyDown(KeyCode.Joystick1Button0)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button2)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button3)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button4)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button5)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button6)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button7)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button8)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button9)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button10)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button11)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button12)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button13)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button14)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button15)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button16)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button17)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button18)) LastFrameInputMode = InputMode.Controller;
            else if (Input.GetKeyDown(KeyCode.Joystick1Button19)) LastFrameInputMode = InputMode.Controller;
            else LastFrameInputMode = InputMode.Keyboard;
        }
    }

    public enum InputMode
    {
        Controller,
        Keyboard
    }
}
